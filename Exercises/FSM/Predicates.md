# Predicate Exercises

### Exercise 1: Environmental: Environmental Alert Predicate

- **Difficulty:** Easy  
- **Exercise Description:**  
  Implement the `EnvironmentalAlertPredicate` that checks for an environmental alert flag. The predicate should look up a specified key in the blackboard and return `true` if the associated boolean value indicates an active alert. If the key is missing, an appropriate warning should be logged.

- **Requirements:**
  - Retrieve the alert flag from the blackboard using a designated key (e.g., "EnvironmentalAlert").
  - Verify that the retrieved value is a boolean indicating an active alert.
  - Return `true` if an alert is active; otherwise, return `false`.
  - Log a warning if the key is not present on the blackboard.

### Exercise 2: Probabilistic: Random Probability Predicate

- **Difficulty:** Easy  
- **Exercise Description:**  
  Create a `RandomProbabilityPredicate` that returns `true` if a randomly generated value is less than a specified probability threshold. This exercise is designed to practice implementing simple probabilistic checks using random values.

- **Requirements:**
  - Define a probability field that accepts values between 0 and 1.
  - Generate a random value using `Random.value`.
  - Compare the generated random value with the probability threshold.
  - Return `true` if the random value is less than the threshold; otherwise, return `false`.

### Exercise 3: Target: Target Set Predicate

- **Difficulty:** Easy  
- **Exercise Description:**  
  Implement the `TargetSetPredicate` which checks whether a target is set on the blackboard. The predicate should retrieve the target (typically stored as a `UnityEngine.Object`) and return `true` if it is valid (i.e., not null).

- **Requirements:**
  - Retrieve the target from the blackboard using a designated key.
  - Verify that the target is a valid `UnityEngine.Object`.
  - Return `true` if the target is non-null; otherwise, return `false`.
  - Log an appropriate warning if the target is missing.

### Exercise 4: Probabilistic: Random Wait Predicate

- **Difficulty:** Intermediate  
- **Exercise Description:**  
  Develop a `RandomWaitPredicate` that returns `true` only after a random waiting period has elapsed. When first evaluated for a given controller, a random duration should be generated (using specified minimum and maximum wait times) and stored. Subsequent evaluations for that controller must use the same wait duration until it is reset.

- **Requirements:**
  - Define `min` and `max` fields for the wait time.
  - Generate a random wait duration using `Random.Range(min, max)` upon the first evaluation for a controller.
  - Store the start time and the random wait duration for each controller.
  - Evaluate whether the elapsed time since the start time meets or exceeds the wait duration.
  - Provide a method to reset the wait state so that a new random duration can be generated.
  - Validate that `min` is ≥ 0 and `max` is ≥ `min`.

### Exercise 5: Probabilistic: Random Above Threshold Predicate

- **Difficulty:** Intermediate  
- **Exercise Description:**  
  Develop a `RandomAboveThresholdPredicate` that returns `true` if a randomly generated number (within a specified range) is greater than a given threshold. This exercise requires working with numerical ranges and threshold comparisons.

- **Requirements:**
  - Define `min`, `max`, and `threshold` fields.
  - Ensure that the maximum value is greater than the minimum value.
  - Generate a random number using `Random.Range(min, max)`.
  - Return `true` if the generated number is greater than the threshold; otherwise, return `false`.
  - Validate input values as necessary.

### Exercise 6: Environmental: Hour Of Day Predicate

- **Difficulty:** Intermediate  
- **Exercise Description:**  
  Develop an `HourOfDayPredicate` that checks whether the current game time (retrieved from the blackboard) falls within a specified time window. The predicate must correctly handle scenarios where the time window spans midnight (for example, from 18:00 to 06:00).

- **Requirements:**
  - Define `startHour` and `endHour` fields.
  - Retrieve the current time from the blackboard using a designated key (e.g., "GameTime").
  - Determine if the current time falls within the specified time window. Handle wrap-around logic if `startHour` is greater than `endHour`.
  - Return `true` if the current time is within the defined window; otherwise, return `false`.
  - Validate that the provided time values are within the 0 to 24 range and that the window is defined correctly.

### Exercise 7: Target: Distance To Target Predicate

- **Difficulty:** Intermediate  
- **Exercise Description:**  
  Implement the `DistanceToTargetPredicate` that checks whether a target is within a specified maximum distance from the agent. The predicate should calculate the distance between the agent and the target retrieved from the blackboard.

- **Requirements:**
  - Retrieve the target from the blackboard using a designated key.
  - Ensure the target has a valid `Transform` component.
  - Calculate the distance between the agent’s position and the target’s position using `Vector3.Distance`.
  - Return `true` if the distance is less than or equal to a specified maximum; otherwise, return `false`.
  - Log warnings if the target or its required components are missing.

### Exercise 8: Patrol: Line Of Sight Predicate

- **Difficulty:** Challenging  
- **Exercise Description:**  
  Create a `LineOfSightPredicate` that determines whether there is an unobstructed line of sight between the agent and a target. The predicate should retrieve the target from the blackboard, verify its `Transform`, and then use raycasting with a specified layer mask to detect obstacles.

- **Requirements:**
  - Retrieve the target from the blackboard using a designated key.
  - Verify that the target is a valid `UnityEngine.Object` and possesses a `Transform` component.
  - Get the positions of both the agent and the target.
  - Use `Physics.Raycast` to perform a raycast from the agent to the target.
  - Apply a layer mask to filter out irrelevant obstacles.
  - Return `true` if no obstructing object is detected; otherwise, return `false`.
  - Log warnings if necessary, such as when the target is invalid or missing.

