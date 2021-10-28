How to compile and run the code

Navigate via Terminal/CMD to the ../src folder. 
Use the command "fsharpc -a vec2dsmall.fsi vec2dsmall.fs" to combine a library.
Use the command "fsharpc -r vec2dsmall.dll 4i1.fsx" to compile 4i1.fsx
Use the command "fsharpc -r vec2dsmall.dll 4i2.fsx" to compile 4i2.fsx
Use the command "mono 4i1.exe" to run 4i1.exe
Use the command "mono 4i2.exe" to run 4i2.exe


Opgave 4i1

I forhold til den første test af vec2d.len(x,y), testet jeg hvorvidt funktionen kunne regne tal ud, både med negative, positive og med 0. Testen gik rigtig fint, ingen fejl og jeg fik de resultater jeg forventede

Testen af vec2d.ang(x,y) gik ligeså godt. Her blev der også testet hvorvidt funktionen kunne regne med både med negative, positive og med 0. Alt gik fint her også, og jeg fik de resultater jeg forventede

Testen af vec2d.add(x1,y1) (x2,y2) gik ligeså nemt igennem. her testet jeg hvorvidt af to vectors kunne sammensættes, igen med både med negative, positive og med 0. Alt gik fint her også, og jeg fik de resultater jeg forventede


Opgave 4i3 

Step	Linje	Miljø	Binding
1	1	E_0	v = ((v), (1.3, -2.5), ())
2	2	E_0	Printfn " Vector %A: (%f, %f)" v ( vec2d . len v ) ( vec2d . ang v )
3	2	E_0	vec2d.len(v) = ?
4	4	E_1	len = ((x,y), sqrt(x**2.0 + y**2.0, ())
5	4	E_1	((v=(1.3, -2.5), sqrt(x**2.0 + y**2.0, ())
6	5	E_1	return 2.8 ...
7	2	E_0	vec2d.len(v) = 2.8 …
8	2	E_0	vec2d.ang(v) = ?
9	7	E_1	ang = ((x,y), Math.Atan2(y, x), ())
10	7	E_1	((v=(1.3, -2.5), Math.Atan2(y, x), ())
11	8	E_1	return -1.09 ...
12	2	E_0	vec2d.ang(v) = -1.09 …
13	2	E_0	Output = "Vector (1.3, -2.5): (2.8, -1.09)"
14	3	E_0	w = ((w), (-0.1, 0.5), ())
15	4	E_0	printfn " Vector %A: (%f, %f)" w ( vec2d . len w ) ( vec2d . ang w )
16	4	E_0	vec2d.len(w) = ?
17	4	E_1	len = ((x,y), sqrt(x**2.0 + y**2.0, ())
18	4	E_1	((w=(-0.1, 0.5), sqrt(x**2.0 + y**2.0, ())
19	5	E_1	return 0.51 ...
20	4	E_0	vec2d.len(w) = 0.51 …
21	4	E_0	vec2d.ang(W) = ?
22	7	E_1	ang = ((x,y), Math.Atan2(y, x), ())
23	8	E_1	((w=(-0.1, 0.5), Math.Atan2(y, x), ())
24	8	E_1	return 1.77 ...
25	4	E_0	vec2d.ang(w) = -1.77 …
26	4	E_0	Output = "Vector (-0.1, 0.5): (0.51, 1.77)"
27	5	E_0	s = ((s), add v w, ())
28	5	E_0	add v w = ?
29	10	E_1	add = ((x1,y1) (x2, y2), x1+x2, y1+y2, ())
30	10	E_1	((v=(1.3, -2.5), w = (-0.1, 0.5), x1+x2, y1+y2, ())
31	11	E_1	return (1.2, -2.0)
32	5	E_0	add v w = (1.2, -2.0)
33	6	E_0	printfn " Vector %A: (%f, %f)" s ( vec2d . len s ) ( vec2d . ang s )
34	6	E_0	vec2d.len(s) = ?
35	4	E_1	len = ((x,y), sqrt(x**2.0 + y**2.0, ())
36	4	E_1	((s=(1.2, -2.0), sqrt(x**2.0 + y**2.0, ())
37	5	E_1	return 2.33 ...
38	6	E_0	vec2d.len(s) = 2.33 …
39	6	E_0	vec2d.ang(s) = ?
40	7	E_1	ang = ((x,y), Math.Atan2(y, x), ())
41	8	E_1	((s=(1.2, -2.0), Math.Atan2(y, x), ())
42	8	E_1	return -1.03 ...
43	6	E_0	vec2d.ang(s) = -1.03 …
44	6	E_0	Output = "Vector (1.2, -2.0): (2.33, -1.03)"
45	6	E_0	printfn " Vector %A: (%f, %f)" s ( vec2d . len s ) ( vec2d . ang s ) = ()
46	6	E_0	return = ()


Did you discover any errors? Do you get the same output?

Igennem min egen håndkøring fandt jeg ingen fejl i koden, og fik hermed det samme output som hvis jeg havde kørt programmet normalt.
