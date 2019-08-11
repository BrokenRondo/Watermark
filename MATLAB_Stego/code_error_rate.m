function percent=code_error_rate(decoded,src,len)
decoded_text=fopen(decoded,'r');
while ~feof(ifid)
    M=fread(decoded_text,1,'ubit8');
    if isempty(M) 
        break;
    end
    