# Replace Delegation with Inheritance

## Problem
A class contains many simple methods that delegate to all methods of another class.

<img src="before.png" style="width:50%"/>

## Solution
Make the class a delegate inheritor, which makes the delegating methods unnecessary.

<img src="after.png" style="width:30%"/>
