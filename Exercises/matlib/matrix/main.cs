class main{
static void Main(){
	var ma=new matrix("1 2;5 6");
	ma.print();
	var ma2=ma*ma.T;
	(ma2).print();
}
}
