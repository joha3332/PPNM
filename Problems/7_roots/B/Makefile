B_plot.svg: b_plot.gpi Data.txt
	gnuplot $<

Data.txt: Main.exe
	mono $< 1> $@ 2> logB.txt


DLLS = matlib.dll roots.dll
Main.exe:	Main.cs hydrogen.cs $(DLLS)
	mcs Main.cs hydrogen.cs -reference:$(call clist,$(DLLS))

#### Root finder ####
NEWTON = ../A/newton.cs
JACOBIAN = ../A/jacobian.cs

roots.dll: $(NEWTON) $(JACOBIAN) matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

####   Matlib + Solver   ####
MATRIX = ../../matlib/matrix/matrix.cs
VECTOR = ../../matlib/matrix/vector.cs

SOLVER =../../2_Linear_Equations/AB/gs.cs

DRIVER = ../../5_ODE/A/driver.cs
STEPPER = ../../5_ODE/A/rkstep23.cs

matlib.dll: $(MATRIX) $(VECTOR) $(SOLVER) $(DRIVER) $(STEPPER)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe *.dll *.txt *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))