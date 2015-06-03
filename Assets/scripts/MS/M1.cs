using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class M1 : MonoBehaviour {
	public List<pokeMove> pokeListMove;
	public pokeMove Pokemove;
	
	private string pokemon_name;
	private playerStats PlayerStats;
	private Transform Pokemon;
	private GameObject instPokeMove;
	
	/*	pokesM1 = {
		["Bulbasaur"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 1, delay = 3, tipo = "target", dista = 1}},
		["Ivysaur"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Venusaur"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 85, delay = 3, tipo = "target", dista = 1}},
		["Pidgey"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 5, delay = 3, tipo = "target", dista = 1}},
		["Pidgeotto"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Pidgeot"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 65, delay = 3, tipo = "target", dista = 1}},
		["Rattata"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 1, delay = 3, tipo = "target", dista = 1}},
		["Raticate"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 25, delay = 3, tipo = "target", dista = 1}},
		["Spearow"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Fearow"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 50, delay = 3, tipo = "target", dista = 1}},
		["Pikachu"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Nidoran"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Nidorina"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 30, delay = 3, tipo = "target", dista = 1}},
		["Nidoqueen"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 65, delay = 3, tipo = "target", dista = 1}},
		["Nidorino"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 30, delay = 3, tipo = "target", dista = 1}},
		["Nidoking"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 65, delay = 3, tipo = "target", dista = 1}},
		["Vulpix"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 15, delay = 3, tipo = "target", dista = 1}},
		["Ninetales"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 70, delay = 3, tipo = "target", dista = 1}},
		["Ponyta"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Rapidash"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Scyther"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 80, delay = 3, tipo = "target", dista = 1}},
		["Electabuzz"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 80, delay = 3, tipo = "target", dista = 1}},
		["Vaporeon"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Jolteon"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Flareon"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Charmander"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 20, delay = 2, tipo = "target", dista = 1}},
		["Charmeleon"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 40, delay = 2, tipo = "target", dista = 1}},
		["Paras"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 5, delay = 2, tipo = "target", dista = 1}},
		["Mankey"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 15, delay = 2, tipo = "target", dista = 1}},
		["Primeape"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 50, delay = 2, tipo = "target", dista = 1}},
		["Magmar"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 80, delay = 2, tipo = "target", dista = 1}},
		["Pinsir"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 45, delay = 2, tipo = "target", dista = 1}},
		["Kabuto"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 20, delay = 2, tipo = "target", dista = 1}},
		["Kabutops"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 80, delay = 2, tipo = "target", dista = 1}},
		["Snorlax"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 85, delay = 2, tipo = "target", dista = 1}},
		["Charizard"] = {x = {m1 = "dragonclaw", spell = "Dragon Claw", minLv = 85, delay = 3, tipo = "target", dista = 1}},
		["Elder Charizard"] = {x = {m1 = "dragonclaw", spell = "Dragon Claw", minLv = 100, delay = 3, tipo = "target", dista = 1}},
		["Squirtle"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Abra"] = {x = {m1 = "restore", spell = "Restore", minLv = 20, delay = 60, tipo = "area", dista = 0}},
		["Aerodactyl"] = {x = {m1 = "roar", spell = "Roar", minLv = 110, delay = 7, tipo = "target", dista = 5}},
		["Alakazam"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 70, delay = 3, tipo = "area", dista = 1}},
		["Arbok"] = {x = {m1 = "bite", spell = "Bite", minLv = 40, delay = 5, tipo = "target", dista = 1}},
		["Arcanine"] = {x = {m1 = "roar", spell = "Roar", minLv = 90, delay = 4, tipo = "area", dista = 3}},
		["Beedrill"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 25, delay = 6, tipo = "target", dista = 5}},
		["Bellsprout"] = {x = {m1 = "razorleaf", spell = "Razor Leaf", minLv = 1, delay = 3, tipo = "target", dista = 5}},
		["Blastoise"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 80, delay = 5, tipo = "target", dista = 1}},
		["Butterfree"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 30, delay = 6, tipo = "target", dista = 5}},
		["Caterpie"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 1, delay = 3, tipo = "target", dista = 1}},
		["Chansey"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 60, delay = 5, tipo = "target", dista = 1}},
		["Clefable"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 40, delay = 6, tipo = "target", dista = 1}},
		["Clefairy"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 40, delay = 6, tipo = "target", dista = 1}},
		["Cloyster"] = {x = {m1 = "lick", spell = "Lick", minLv = 60, delay = 6, tipo = "target", dista = 1}},
		["Cubone"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Dewgong"] = {x = {m1 = "aquatail", spell = "Aqua Tail", minLv = 65, delay = 4, tipo = "target", dista = 1}},
		["Diglett"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 10, delay = 4, tipo = "area", dista = 0}},
		["Dodrio"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 35, delay = 4, tipo = "area", dista = 0}},
		["Dragonair"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 80, delay = 2, tipo = "target", dista = 1}},
		["Dragonite"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 100, delay = 2, tipo = "target", dista = 1}},
		["Dratini"] = {x = {m1 = "aquatail", spell = "Aqua Tail", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Doduo"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 20, delay = 5, tipo = "area", dista = 0}},
		["Dugtrio"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 35, delay = 4, tipo = "area", dista = 0}},
		["Eevee"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 20, delay = 2, tipo = "area", dista = 0}},
		["Ekans"] = {x = {m1 = "bite", spell = "Bite", minLv = 15, delay = 2, tipo = "target", dista = 1}},
		["Electrode"] = {x = {m1 = "thundershock", spell = "Thunder Shock", minLv = 35, delay = 3, tipo = "area", dista = 0}},
		["Exeggcute"] = {x = {m1 = "hypnosis", spell = "Hypnosys", minLv = 20, delay = 5, tipo = "target", dista = 7}},
		["Exeggutor"] = {x = {m1 = "hypnosis", spell = "Hypnosys", minLv = 55, delay = 5, tipo = "target", dista = 7}},
		["Farfetch\"d"] = {x = {m1 = "peck", spell = "Peck", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Gastly"] = {x = {m1 = "lick", spell = "Lick", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Gengar"] = {x = {m1 = "lick", spell = "Lick", minLv = 80, delay = 5, tipo = "target", dista = 1}},
		["Geodude"] = {x = {m1 = "rockthrow", spell = "Rock Throw", minLv = 15, delay = 6, tipo = "target", dista = 5}},
		["Gloom"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 25, delay = 20, tipo = "target", dista = 7}},
		["Golbat"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 30, delay = 5, tipo = "target", dista = 5}},
		["Goldeen"] = {x = {m1 = "hornattack", spell = "Horn Atack", minLv = 10, delay = 3, tipo = "target", dista = 4}},
		["Golduck"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 55, delay = 5, tipo = "target", dista = 1}},
		["Golem"] = {x = {m1 = "rockthrow", spell = "Rock Throw", minLv = 80, delay = 6, tipo = "target", dista = 5}},
		["Graveler"] = {x = {m1 = "rockthrow", spell = "Rock Throw", minLv = 40, delay = 6, tipo = "target", dista = 5}},
		["Grimer"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 15, delay = 8, tipo = "target", dista = 4}},
		["Growlithe"] = {x = {m1 = "roar", spell = "Roar", minLv = 20, delay = 4, tipo = "target", dista = 3}},
		["Gyarados"] = {x = {m1 = "roar", spell = "Roar", minLv = 95, delay = 3, tipo = "area", dista = 0}},
		["Haunter"] = {x = {m1 = "lick", spell = "Lick", minLv = 45, delay = 2, tipo = "target", dista = 1}},
		["Hitmonchan"] = {x = {m1 = "triplepunch", spell = "Triple Punch", minLv = 60, delay = 3, tipo = "target", dista = 1}},
		["Hitmonlee"] = {x = {m1 = "triplekick", spell = "Triple Kick", minLv = 60, delay = 3, tipo = "target", dista = 1}},
		["Horsea"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 10, delay = 5, tipo = "target", dista = 4}},
		["Hypno"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 55, delay = 6, tipo = "target", dista = 1}},
		["Jigglypuff"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Jynx"] = {x = {m1 = "lovelykiss", spell = "Lovely Kiss", minLv = 75, delay = 4, tipo = "target", dista = 7}},
		["Kadabra"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 45, delay = 6, tipo = "area", dista = 0}},
		["Kakuna"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 15, delay = 3, tipo = "target", dista = 5}},
		["Kangaskhan"] = {x = {m1 = "bite", spell = "Bite", minLv = 80, delay = 2, tipo = "target", dista = 1}},
		["Kingler"] = {x = {m1 = "bubble", spell = "Bubbles", minLv = 40, delay = 3, tipo = "target", dista = 5}},
		["Koffing"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 15, delay = 4, tipo = "target", dista = 4}},
		["Krabby"] = {x = {m1 = "bubble", spell = "Bubbles", minLv = 15, delay = 5, tipo = "target", dista = 5}},
		["Lapras"] = {x = {m1 = "hornattack", spell = "Horn Atack", minLv = 80, delay = 4, tipo = "target", dista = 5}},
		["Lickitung"] = {x = {m1 = "lick", spell = "Lick", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Machamp"] = {x = {m1 = "triplepunch", spell = "Triple Punch", minLv = 70, delay = 5, tipo = "target", dista = 1}},
		["Machoke"] = {x = {m1 = "triplepunch", spell = "Triple Punch", minLv = 47, delay = 4, tipo = "target", dista = 1}},
		["Machop"] = {x = {m1 = "triplepunch", spell = "Triple Punch", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Magikarp"] = {x = {m1 = "splash", spell = "Splash", minLv = 1, delay = 2, tipo = "target", dista = 1}},
		["Magnemite"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 15, delay = 4, tipo = "target", dista = 5}},
		["Magneton"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 40, delay = 5, tipo = "target", dista = 5}},
		["Marowak"] = {x = {m1 = "headbutt", spell = "Head Butt", minLv = 40, delay = 2, tipo = "target", dista = 1}},
		["Meowth"] = {x = {m1 = "slash", spell = "Slash", minLv = 15, delay = 5, tipo = "target", dista = 1}},
		["Metapod"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 15, delay = 2, tipo = "target", dista = 5}},
		["Mr.Mime"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 70, delay = 6, tipo = "target", dista = 1}},
		["Muk"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 35, delay = 4, tipo = "target", dista = 4}},
		["Oddish"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 1, delay = 3, tipo = "target", dista = 7}},
		["Omanyte"] = {x = {m1 = "bubble", spell = "Bubbles", minLv = 20, delay = 3, tipo = "target", dista = 5}},
		["Omastar"] = {x = {m1 = "bubble", spell = "Bubbles", minLv = 80, delay = 5, tipo = "target", dista = 5}},
		["Onix"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 50, delay = 5, tipo = "area", dista = 0}},
		["Parasect"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 10, tipo = "target", dista = 7}},
		["Persian"] = {x = {m1 = "slash", spell = "Slash", minLv = 30, delay = 3, tipo = "target", dista = 1}},
		["Poliwag"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 5, delay = 2, tipo = "target", dista = 1}},
		["Poliwhirl"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 25, delay = 3, tipo = "target", dista = 4}},
		["Poliwrath"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 65, delay = 5, tipo = "target", dista = 4}},
		["Porygon"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 40, delay = 5, tipo = "target", dista = 5}},
		["Psyduck"] = {x = {m1 = "watergun", spell = "Water Gun", minLv = 24, delay = 5, tipo = "area", dista = 0}},
		["Raichu"] = {x = {m1 = "megakick", spell = "Mega Kick", minLv = 45, delay = 5, tipo = "target", dista = 1}},
		["Rhydon"] = {x = {m1 = "irontail", spell = "Iron Tail", minLv = 60, delay = 4, tipo = "target", dista = 1}},
		["Rhyhorn"] = {x = {m1 = "irontail", spell = "Iron Tail", minLv = 30, delay = 5, tipo = "target", dista = 1}},
		["Sandshrew"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 1, delay = 3, tipo = "area", dista = 0}},
		["Sandslash"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 55, delay = 4, tipo = "area", dista = 0}},
		["Seadra"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 45, delay = 4, tipo = "target", dista = 4}},
		["Seaking"] = {x = {m1 = "hornattack", spell = "Horn Atack", minLv = 35, delay = 3, tipo = "target", dista = 5}},
		["Seel"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 20, delay = 4, tipo = "target", dista = 1}},
		["Shellder"] = {x = {m1 = "lick", spell = "Lick", minLv = 10, delay = 4, tipo = "target", dista = 1}},
		["Slowbro"] = {x = {m1 = "aquatail", spell = "Aqua Tail", minLv = 45, delay = 5, tipo = "target", dista = 1}},
		["Slowpoke"] = {x = {m1 = "aquatail", spell = "Aqua Tail", minLv = 15, delay = 3, tipo = "target", dista = 1}},
		["Starmie"] = {x = {m1 = "swift", spell = "Swift", minLv = 35, delay = 5, tipo = "target", dista = 5}},
		["Staryu"] = {x = {m1 = "swift", spell = "Swift", minLv = 15, delay = 5, tipo = "target", dista = 5}},
		["Tangela"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 8, tipo = "target", dista = 7}},
		["Tauros"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 45, delay = 4, tipo = "target", dista = 1}},
		["Tentacool"] = {x = {m1 = "acid", spell = "Acid", minLv = 15, delay = 4, tipo = "area", dista = 0}},
		["Tentacruel"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 75, delay = 5, tipo = "target", dista = 5}},
		["Venomoth"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 5, tipo = "target", dista = 7}},
		["Venonat"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 20, delay = 3, tipo = "target", dista = 7}},
		["Victreebel"] = {x = {m1 = "razorleaf", spell = "Razor Leaf", minLv = 50, delay = 4, tipo = "area", dista = 5}},
		["Vileplume"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 4, tipo = "target", dista = 7}},
		["Voltorb"] = {x = {m1 = "thundershock", spell = "Thunder Shock", minLv = 20, delay = 5, tipo = "area", dista = 0}},
		["Wartortle"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 40, delay = 4, tipo = "target", dista = 1}},
		["Weedle"] = {x = {m1 = "hornattack", spell = "Horn Atack", minLv = 1, delay = 3, tipo = "target", dista = 5}},
		["Weepinbell"] = {x = {m1 = "razorleaf", spell = "Razor Leaf", minLv = 20, delay = 3, tipo = "target", dista = 5}},
		["Weezing"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 35, delay = 6, tipo = "target", dista = 4}},
		["Wigglytuff"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 45, delay = 4, tipo = "target", dista = 1}},
		["Zubat"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 10, delay = 3, tipo = "target", dista = 5}},
		["Aipom"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 45, delay = 4, tipo = "target", dista = 1}},
		["Ampharos"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 80, delay = 3, tipo = "target", dista = 1}},
		["Ariados"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 35, delay = 6, tipo = "target", dista = 5}},
		["Azumarill"] = {x = {m1 = "swift", spell = "Swift", minLv = 35, delay = 5, tipo = "target", dista = 5}},
		["Bayleef"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 45, delay = 3, tipo = "target", dista = 1}},
		["Bellossom"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 20, tipo = "target", dista = 7}},
		["Blissey"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 75, delay = 5, tipo = "target", dista = 1}},
		["Chikorita"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Chinchou"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 22, delay = 5, tipo = "target", dista = 5}},
		["Cleffa"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 5, delay = 5, tipo = "target", dista = 1}},
		["Corsola"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Crobat"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 50, delay = 5, tipo = "target", dista = 5}},
		["Croconaw"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Cyndaquil"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 20, delay = 2, tipo = "target", dista = 1}},
		["Delibird"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 25, delay = 3, tipo = "target", dista = 1}},
		["Donphan"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 60, delay = 4, tipo = "area", dista = 0}},
		["Dunsparce"] = {x = {m1 = "slash", spell = "Slash", minLv = 30, delay = 5, tipo = "target", dista = 1}},
		["Elekid"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Espeon"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 55, delay = 3, tipo = "area", dista = 1}},
		["Magby"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 10, delay = 2, tipo = "target", dista = 1}},
		["Magcargo"] = {x = {m1 = "ember", spell = "Ember", minLv = 40, delay = 6, tipo = "target", dista = 5}},
		["Mantine"] = {x = {m1 = "bubble", spell = "Bubbles", minLv = 70, delay = 3, tipo = "target", dista = 5}},
		["Mareep"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 20, delay = 3, tipo = "target", dista = 1}},
		["Marill"] = {x = {m1 = "swift", spell = "Swift", minLv = 15, delay = 5, tipo = "target", dista = 5}},
		["Meganium"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 75, delay = 3, tipo = "target", dista = 1}},
		["Miltank"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 50, delay = 3, tipo = "target", dista = 1}},
		["Misdreavus"] = {x = {m1 = "shadowball", spell = "Shadow Ball", minLv = 50, delay = 5, tipo = "target", dista = 5}},
		["Murkrow"] = {x = {m1 = "DARK", spell = "DARK", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Natu"] = {x = {m1 = "restore", spell = "Restore", minLv = 20, delay = 60, tipo = "area", dista = 0}},
		["Noctowl"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Octillery"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Phanpy"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 25, delay = 4, tipo = "area", dista = 0}},
		["Pichu"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 5, delay = 3, tipo = "target", dista = 1}},
		["Piloswine"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 60, delay = 3, tipo = "target", dista = 1}},
		["Pineco"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 30, delay = 6, tipo = "target", dista = 5}},
		["Politoed"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 65, delay = 8, tipo = "target", dista = 4}},
		["Porygon2"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 60, delay = 5, tipo = "target", dista = 5}},
		["Pupitar"] = {x = {m1 = "rockthrow", spell = "Rock Throw", minLv = 40, delay = 6, tipo = "target", dista = 5}},
		["Quagsire"] = {x = {m1 = "swift", spell = "Swift", minLv = 40, delay = 5, tipo = "target", dista = 5}},
		["Quilava"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 40, delay = 2, tipo = "target", dista = 1}},
		["Qwilfish"] = {x = {m1 = "acid", spell = "Acid", minLv = 22, delay = 4, tipo = "area", dista = 0}},
		["Remoraid"] = {x = {m1 = "splash", spell = "Splash", minLv = 1, delay = 2, tipo = "target", dista = 1}},
		["Feraligatr"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 85, delay = 3, tipo = "target", dista = 1}},
		["Flaaffy"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 50, delay = 3, tipo = "target", dista = 1}},
		["Forretress"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 45, delay = 6, tipo = "target", dista = 5}},
		["Furret"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Girafarig"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 50, delay = 3, tipo = "area", dista = 1}},
		["Gligar"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 60, delay = 4, tipo = "area", dista = 0}},
		["Granbull"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 40, delay = 3, tipo = "target", dista = 1}},
		["Heracross"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 35, delay = 6, tipo = "target", dista = 5}},
		["Hitmontop"] = {x = {m1 = "triplekick", spell = "Triple Kick Lee", minLv = 60, delay = 3, tipo = "target", dista = 1}},
		["Hoothoot"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Houndoom"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 50, delay = 2, tipo = "target", dista = 1}},
		["Houndour"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 25, delay = 2, tipo = "target", dista = 1}},
		["Igglybuff"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 5, delay = 5, tipo = "target", dista = 1}},
		["Kingdra"] = {x = {m1 = "mudshot", spell = "Mud Shot", minLv = 45, delay = 8, tipo = "target", dista = 4}},
		["Lanturn"] = {x = {m1 = "supersonic", spell = "Super Sonic", minLv = 35, delay = 5, tipo = "target", dista = 5}},
		["Larvitar"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 15, delay = 4, tipo = "area", dista = 0}},
		["Ledyba"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 15, delay = 6, tipo = "target", dista = 5}},
		["Ledian"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 25, delay = 6, tipo = "target", dista = 5}},
		["Hoppip"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 1, delay = 3, tipo = "target", dista = 1}},
		["Jumpluff"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 30, delay = 3, tipo = "target", dista = 1}},
		["Scizor"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 100, delay = 3, tipo = "target", dista = 1}},
		["Shuckle"] = {x = {m1 = "stringshot", spell = "String Shot", minLv = 20, delay = 6, tipo = "target", dista = 5}},
		["Skarmory"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 65, delay = 3, tipo = "target", dista = 1}},
		["Skiploom"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 15, delay = 3, tipo = "target", dista = 1}},
		["Slowking"] = {x = {m1 = "aquatail", spell = "Aqua Tail", minLv = 60, delay = 4, tipo = "target", dista = 1}},
		["Slugma"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 20, delay = 2, tipo = "target", dista = 1}},
		["Smeargle"] = {x = {m1 = "slash", spell = "Slash", minLv = 30, delay = 5, tipo = "target", dista = 1}},
		["Smoochum"] = {x = {m1 = "lovelykiss", spell = "Lovely Kiss", minLv = 10, delay = 4, tipo = "target", dista = 7}},
		["Sneasel"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 60, delay = 2, tipo = "target", dista = 1}},
		["Snubbull"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 25, delay = 3, tipo = "target", dista = 1}},
		["Stantler"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 55, delay = 3, tipo = "target", dista = 1}},
		["Steelix"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 80, delay = 4, tipo = "area", dista = 0}},
		["Sunflora"] = {x = {m1 = "razorleaf", spell = "Razor Leaf", minLv = 35, delay = 3, tipo = "target", dista = 5}},
		["Sunkern"] = {x = {m1 = "razorleaf", spell = "Razor Leaf", minLv = 5, delay = 3, tipo = "target", dista = 5}},
		["Swinub"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Teddiursa"] = {x = {m1 = "quickattack", spell = "Quick Attack", minLv = 25, delay = 3, tipo = "target", dista = 1}},
		["Togepi"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 15, delay = 5, tipo = "target", dista = 1}},
		["Togetic"] = {x = {m1 = "doubleslap", spell = "Double Slap", minLv = 50, delay = 5, tipo = "target", dista = 1}},
		["Totodile"] = {x = {m1 = "headbutt", spell = "Headbutt", minLv = 15, delay = 3, tipo = "target", dista = 1}},
		["Typhlosion"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 85, delay = 2, tipo = "target", dista = 1}},
		["Tyranitar"] = {x = {m1 = "sandattack", spell = "Sand Attack", minLv = 90, delay = 4, tipo = "area", dista = 0}},
		["Tyrogue"] = {x = {m1 = "triplepunch", spell = "Triple Punch", minLv = 10, delay = 3, tipo = "target", dista = 1}},
		["Ursaring"] = {x = {m1 = "scratch", spell = "Scratch", minLv = 85, delay = 2, tipo = "target", dista = 1}},
		["Wobbuffet"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 45, delay = 3, tipo = "area", dista = 1}},
		["Wooper"] = {x = {m1 = "swift", spell = "Swift", minLv = 20, delay = 5, tipo = "target", dista = 5}},
		["Xatu"] = {x = {m1 = "psybeam", spell = "Psy Beam", minLv = 45, delay = 3, tipo = "area", dista = 1}},
		["Yanma"] = {x = {m1 = "absorv", spell = "Absorb", minLv = 50, delay = 20, tipo = "target", dista = 7}},
*/
	
	// Use this for initialization
	void Start () {
		pokeListMove = new List<pokeMove>();
		
		Pokemove = new pokeMove();
		Pokemove.pokename = "Bulbasaur";
		Pokemove.move = "quickattack";
		Pokemove.move_spell = "Quick Attack";
		Pokemove.move_minLv = 1;
		Pokemove.move_delay = 3;
		Pokemove.move_range = "target";
		Pokemove.move_dista = 1;
		pokeListMove.Add ( Pokemove );
		
		Pokemove = new pokeMove();
		Pokemove.pokename = "Ivysaur";
		Pokemove.move = "quickattack";
		Pokemove.move_spell = "Quick Attack";
		Pokemove.move_minLv = 1;
		Pokemove.move_delay = 3;
		Pokemove.move_range = "target";
		Pokemove.move_dista = 1;
		pokeListMove.Add ( Pokemove );
		
		Pokemove = new pokeMove();
		Pokemove.pokename = "Magmar";
		Pokemove.move = "flamethrower";
		Pokemove.move_spell = "Scratch";
		Pokemove.move_minLv = 80;
		Pokemove.move_delay = 2;
		Pokemove.move_range = "target";
		Pokemove.move_dista = 1;
		Pokemove.move_type = "fire";
		pokeListMove.Add ( Pokemove );
		
	}
	
	// Update is called once per frame
	bool Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerStats = GetComponent<playerStats>();
			Pokemon = PlayerStats.Pokemon;
			if(Pokemon != null){
				pokemon_name = PlayerStats.PokemonName;
				for (int i = 0; i < pokeListMove.Count; i++){
					if(pokeListMove[i].pokename == pokemon_name){
						// DELAY - COOLDOWN
						if (pokeListMove[i].move_curr_delay <= Time.time){
							if(pokeListMove[i].move_range == "target"){
								if(PlayerStats.Target == null){
									print ( "MOSTRAR MENSAGENS DE QUE NAO EH POSSIVEL - TODO");
									return false;
								}
								int dist =  Mathf.RoundToInt( Vector3.Distance(Pokemon.position, PlayerStats.Target.transform.position) );
								if(dist > pokeListMove[i].move_dista){
									print ( " MOSTRAR MENSAGENS DE QUE NAO EH POSSIVEL - TODO");
									return false;
								}
								
							}
							instPokeMove = Instantiate( (GameObject)Resources.Load("moves/"+pokeListMove[i].move, typeof(GameObject)) , Pokemon.position, Pokemon.rotation) as GameObject;
							instPokeMove.transform.parent = Pokemon.transform;
							
							pokeListMove[i].move_curr_delay = Time.time + pokeListMove[i].move_delay;
							//FAZER AQUI TODO O RESTO PARA QUE SEJA DISPARADO
						}
						
					}
				}
			}
		}
		return true;
	}
	
}
