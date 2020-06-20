class hello2{
	static void Main(){
		string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
		System.Console.Write($"hello {userName} \n");
	}
}
