-> main

===main===
Hello! this is a test dialog!
We are going to ask you a few questions!
Which do you like more?
    + [helping]
        -> chosen("helping")
    + [destroying my enemies]
        -> chosen("destroying my enemies")
    + [pokemon]
        -> chosen("pokemon")
    + [digimon]
        -> chosen("digimon")
    
=== chosen(answer)===
You chose {answer}!
->END