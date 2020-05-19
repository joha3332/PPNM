All: PlotA.svg PlotB.svg PlotC.svg 

########## Problem A ##############

PlotA.svg: A/PlotA.svg
	cp A/PlotA.svg ./

A/PlotA.svg: A/Makefile
	cd a/ && make

########## Problem B ##############

PlotB.svg: B/PlotB.svg
	cp b/PlotB.svg ./

B/PlotB.svg: b/Makefile
	cd b/ && make

########## Problem C ##############

PlotC.svg: C/PlotC.svg
	cp c/PlotC.svg ./

C/PlotC.svg: C/Makefile
	cd c/ && make



clean:
	cd a/ && make clean
	cd b/ && make clean
	cd c/ && make clean
	rm -f *.svg

