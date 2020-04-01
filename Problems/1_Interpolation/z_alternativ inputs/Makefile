All: PlotA.svg Out_lspline_integral.txt PlotB.svg PlotB_slope.svg PlotB_integral.svg PlotC.svg PlotC_slope.svg PlotC_integral.svg

########## Problem A ##############

PlotA.svg: a/PlotA.svg
	cp a/PlotA.svg ./
Out_lspline_integral.txt: a/Out_lspline_integral.txt
	cp a/Out_lspline_integral.txt ./

a/PlotA.svg: a/Makefile
	cd a/ && make

########## Problem B ##############

PlotB.svg: b/PlotB.svg
	cp b/PlotB.svg ./
PlotB_slope.svg: b/PlotB_slope.svg
	cp b/PlotB_slope.svg ./
PlotB_integral.svg: b/PlotB_integral.svg
	cp b/PlotB_integral.svg ./

b/PlotB.svg: b/Makefile
	cd b/ && make

########## Problem C ##############

PlotC.svg: probC/PlotC.svg
	cp probC/PlotC.svg ./
PlotC_slope.svg: c/PlotC_slope.svg
	cp c/PlotC_slope.svg ./
PlotC_integral.svg: b/PlotC_integral.svg
	cp c/PlotC_integral.svg ./

probC/PlotC.svg: probC/Makefile
	cd probC/ && make



clean:
	rm -f Out* *.svg

