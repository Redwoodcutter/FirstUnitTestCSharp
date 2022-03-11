# FirstUnitTestC#
## Nunit Assertion Model

 # Classic Model
 -Assert.AreEqueal(30, result);
 -Assert.IsTrue(result);
 # Constrait Model ( Assert.That )
 The constraint-based assert model uses a single method of the assert class for all assertions. The logic necessary to carry out each assertion is embedded in the constraint object passed as the second parameter to that method. 
 -Assert.That(30, IsEqual(result));
 -Assert.That(Result, IsFalse);