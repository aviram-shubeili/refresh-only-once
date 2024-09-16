# refresh-only-once
Idea of a mechanism that manage multiple refresh requests in a way that only a single refresh will be executed at the end of all requests.


## How to run in GitHub Codespaces

1. Open the repository in GitHub Codespaces.
2. Navigate to the `/RefreshOnlyOnce` directory.
3. Open a terminal in the Codespace.
4. Run the following command to restore the dependencies:

```bash
dotnet run --verbosity quiet
```


### Demo
![2024-06-28_17-53-38](https://github.com/aviram-shubeili/async-refresh-only-once/assets/62931783/e86430fd-ebc0-4365-824c-aec9aa7f3470)


## Sequence Flow
### Problem flow
```mermaid
---
title: Problem flow
---
sequenceDiagram

	participant ControllerA
participant WorkflowA
participant ControllerB
participant WorkflowB
participant ControllerC
box Aqua
participant StateRefresher
end

	ControllerA ->> WorkflowA : Execute()
	WorkflowA ->> ControllerB : Call()
	ControllerB ->> WorkflowB : Execute()
	WorkflowB ->> ControllerC : DoSomethingC()
	ControllerC -->> WorkflowB : ret
	WorkflowB ->> StateRefresher : RefreshState()
	StateRefresher -->> WorkflowB : ret
	WorkflowB -->> ControllerB : ret
	ControllerB -->> WorkflowA : ret
	WorkflowA ->> StateRefresher : RefreshState()
	StateRefresher -->> WorkflowA : ret

```

### Possible Solution flow
```mermaid
---
title: Possible Solution flow
---
sequenceDiagram

	participant ControllerA
participant WorkflowA
participant ControllerB
participant WorkflowB
participant ControllerC
box Aqua
participant StateRefresher
end

	ControllerA ->> WorkflowA : Execute()
	WorkflowA ->> StateRefresher : NotifyRefreshNeeded()
	rect gray
	StateRefresher -->> StateRefresher : _openRefreshRequests++;
	end
	StateRefresher -->> WorkflowA : ret
	WorkflowA ->> ControllerB : Call()
	ControllerB ->> WorkflowB : Execute()
	WorkflowB ->> StateRefresher : NotifyRefreshNeeded()
	rect gray
	StateRefresher -->> StateRefresher : _openRefreshRequests++;
	end
	StateRefresher -->> WorkflowB : ret
	WorkflowB ->> ControllerC : DoSomethingC()
	ControllerC -->> WorkflowB : ret
	WorkflowB ->> StateRefresher : RefreshState()
	rect gray
	StateRefresher -->> StateRefresher : _openRefreshRequests--;
	end
	StateRefresher -->> WorkflowB : ret
	WorkflowB -->> ControllerB : ret
	ControllerB -->> WorkflowA : ret
	WorkflowA ->> StateRefresher : RefreshState()
		rect gray
	StateRefresher -->> StateRefresher : _openRefreshRequests-- & Refresh();
	end
	StateRefresher -->> WorkflowA : ret


```