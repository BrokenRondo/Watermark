function MyPSNR(A,B)
if(A==B)
    error('ÊäÈëµÄÍ¼Æ¬ÏàÍ¬£¡')
end
A=rgb2gray(A);
B=rgb2gray(B);
max2_A=max(max(A));
max2_B=max(max(A));
min2_A=min(min(A));
min2_B=min(min(B));
%if max2_A>1 || max2_B>1 || min2_A<0 || min2_B <0
%    error('Í¼Æ¬¾ØÕó·¶Î§´íÎó')
%end

error_diff=A-B;
decibels=20*log10(1/(sqrt(mean(mean(error_diff.^2)))));

disp(sprintf('PSNR=+%5.2fdb',decibels));



