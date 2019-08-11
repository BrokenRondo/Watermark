function out = QIM(value, level, bit)
abs_value = abs(value);
half = level/2;
i_value = floor(abs_value/half);
if bit == 0
    if mod(i_value,2)==0
        out = i_value*half;
    else
        out = (i_value+1)*half;
    end
else
    if mod(i_value,2)==1
        out = i_value*half;
    else
        out = (i_value+1)*half;
    end
end
if out == 0
    out = level;
end
if value<0
    out = -out;
end
end