How to use:

Attaching Scripts

1 - Attach the script "Pooling" to a GameObject, such as you manager.
2 - Attach the scipt "Pooled" to the prefab to be spawned.


Using Pooling

Pooling.cs

Prefab: Prefab you want to instantiate
Parent: Game Object you want the spawnables to be child of. Not required
Instances: How many instances to be created at the begginning
On Demand: Whether you want or not Pooling to create more instances in case there's no instance available
Max Intances: Maximum amount of instances Pooling is allowed to create

----------------------------

Pooled.cs

On Enable: List of callbacks needed to be called when the object is activated
On Disable: List of callbacks needed to be called when the objects returns to the pool

-----------------------------

Instantiating objects

Add a reference to Pooling on your script, such as your manager

When you need an instance, call the "Pull" method. It returns an instance(not active). All you need to to is to activate to object (GameObject.setActive(true)).

When the object is out of scope, disable it (GameObject.SetActive(false)) and it will return to the pool.
