Game Jam Repo

Three towers spawn minions

Minions once spawned will target and move twords the battleground.
	After arriving at the battle ground the isInBattleground flag is set
	and the nearest enemy is targeted.

When opposing minions collide they run the Hut() method on eachother.

the Hurt() method will bounce the enemys away from eachother to prevent trggering extra times
	as well as decremnet health and distroy dead minions.


	