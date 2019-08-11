function out= Logistic(in,u)
x=zeros(1,10);
x(1)=0.961;
for i=2:10
    x(i)=3.57111*x(i-1)*(1-x(i-1));
end
disp(x);
out=x;

end