function bit_out = QIM_OUT(out_value, level)
half=level/2;
c=0;
abs_value = abs(out_value);
a=double(c);
a=abs_value/half;
b=floor(abs_value/half);
if a-b>0.5
    b=b+1;
    if mod(b,2)==1   %��һλ�����ֵ����������������������bitΪ1
        bit_out=1;
    else
        bit_out=0;%����Ϊ0
    end
    %%a=2��a=1�ֱ��Ӧ��ԭʼ����ֵΪ0ʱ����ӦbitΪ0����1�����
elseif a==2
    bit_out=0;
elseif a==1
    bit_out=1;
else
     if mod(b,2)==1  %���������ȡ��������ͬ���������������bitΪ1������Ϊ0
        bit_out=1;
    else
        bit_out=0;
     end 
end
end