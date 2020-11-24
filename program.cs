x=0.1:1/19:1.11;
h1=rand(1);
h2=rand(1);
h3=rand(1);
learning_rate=0.25;
r1_value=0.16;
r2_value=0.16;
c1_value=0.175;
c2_value=0.88;

%desired output
for j=1:20
desired_output(j)=(1+0.6*sin(2*pi*x(j)/0.7))+0.3*sin(2*pi*x(j))/2;
end


%training part
for i=1:25000
    for j= 1:20
       radial_basis_function1=exp(-1*(x(j)-c1_value)^2/(2*r1_value^2));
       radial_basis_function2=exp(-1*(x(j)-c2_value)^2/(2*r2_value^2));
       y(j)=radial_basis_function1*h1+h2*radial_basis_function2+h3;
       
       %error :
       e(j)=desired_output(j)-y(j);
       
       %updating
        h1=h1+learning_rate*e(j)*radial_basis_function1;
        h2=h2+learning_rate*e(j)*radial_basis_function2;
        h3=h3+learning_rate*e(j);
    end
end
plot (x,desired_output,x,y)
       
