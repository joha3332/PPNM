using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class  main
{
    static void Main(){

    for(int n=200;n<1001;n+=100){
        matrix A=rand_matrix(n);
        vector v=rand_vector(n);
        vector b=v.copy();
        

        Stopwatch cd_time = new Stopwatch();
        cd_time.Start();
        var cd=new cholesky(A);
        vector x_cd=cd.solve(v);
        cd_time.Stop();


        Stopwatch qr_time = new Stopwatch();
        qr_time.Start();
        var qr=new gs(A);
        var x_qr=qr.solve(b);
        qr_time.Stop();

        /////  matrix dimension n*n         cd_runtime         qr_runtime 
        WriteLine($"{n} \t {cd_time.ElapsedMilliseconds} \t {qr_time.ElapsedMilliseconds}");
    }
    } //Method: Main

    // Generate a real symmetric positive-definite matrix
    static matrix rand_matrix(int n){
        matrix M= new matrix(n,n);
        var rand= new Random(1);
    
        for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
        M[i,j]=2*(rand.NextDouble()-0.5);
    
        M=M*M.transpose()/n;
        return M;
    } //Method: rand_matrix


    // Generate a real vector
    static vector rand_vector(int n){
        vector v= new vector(n);
        var rand= new Random(1);
    
        for(int i=0;i<n;i++)
        v[i]=2*(rand.NextDouble()-0.5);

        return v;
    } //Method: rand_matrix

}// class: main










