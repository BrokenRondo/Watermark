function bit_out = QIM_OUT(out_value, level)
half=level/2;
c=0;
abs_value = abs(out_value);
a=double(c);
a=abs_value/half;
b=floor(abs_value/half);
if a-b>0.5
    b=b+1;
    if mod(b,2)==1   %进一位后的数值如果是奇数，则设置输出的bit为1
        bit_out=1;
    else
        bit_out=0;%否则为0
    end
    %%a=2和a=1分别对应在原始像素值为0时，对应bit为0或者1的情况
elseif a==2
    bit_out=0;
elseif a==1
    bit_out=1;
else
     if mod(b,2)==1  %如果是向下取整的数，同样奇数，设置输出bit为1，否则为0
        bit_out=1;
    else
        bit_out=0;
     end 
end
end