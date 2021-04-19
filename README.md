# Flocking Algorithm in Unity
a flocking algorithm is a set of behaviors applied to aset of agents so that those agents can move sensibly in a group and appear to be coordinated by some common controller, much like a flock of birds.  
The concept of flocking was initially developped in 1987 by Craig Reynolds and has been adapted to a number of languages and environments from there, here we will see an implementation of it in unity.

<hr/>

## Elements of flocking
in a basic flocking implementation, this immergeant coordenation is the result of 3 behaviors:
- **cohesion :**  
    cohesion compels each agent in a flock to stay grouped with its neighbors, the agent does this by finding the mid-point between its neighbors and navigating towards it.
- **alignment :**  
    alignement encourages the agents to move in a common direction, each agent will set its heading to the average heading of all its neighbors.
- **avoidance :**  
    avoidance, sometimes called seperation, helps prevent collisions and overlap of the agents. Agents will look at the neighbors that they feel are too close to them withing some distance that is less the neighbor radius, and if any neighbors are within this limit, the agent will navigate away from those neighbors.

it is worth noting that each behavior takes into account all of each agent's neighbors within a certain radius.  
each of these behaviors is calculated and then they are combined using some user defined weighting system to determine the ultimate destination of each agent.
***
a common implementation is to use a core *Flock* object, however it shouldn't be assumed that this object is coordinating all of its agents, rather the *Flock* object serves as an iterator for each agent to execute its own flocking behavior
```csharp
FlockAgent[] agents;
FlockBehavior behavior;

void Update() {
    ...
    foreach(FlockAgent a in agents) {
        ...
        behavior.CalculateMove(a);
        ...
    }
    ...
}
```
Additionally, this implementation allows for a modular design of the behaviors, each behavior can be implemented in its own *Scriptable Object* and then grouped in a composite *Sciptable Object*. This allows the easy implementation of any new desired behavior.
***
![result](./result.gif)
