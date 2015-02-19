# SelectWhile
Provides a Linq SelectWhile method

## Example
Create some list:
```cs
var animals = new[]
{
    new Animal{Type = "Cat"}, 
    new Animal{Type = "Dog"}, 
    new Animal{Type = "Unicorn", IsExtinct = true}
};
```
Get the names of all living animals:
```cs
var existingAnimals = animals.SelectWhile(a => !a.IsExtinct, 
                                          a => a.Type);
// -> "Cat", "Dog"
```
If you want to filter on the result (instead of the source as just shown), switch the statements:
```cs
var threeLetterAnimals = animals.SelectWhile(a => a.Type, 
                                             a => a.Length == 3);
// -> "Cat", "Dog"
```

## Install
    Install-Package SelectWhile
