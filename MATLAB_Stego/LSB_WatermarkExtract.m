function LSB_WatermarkExtract(tobeExtracted)
loc=1;
Binary_array=[];

Marked=jpeg_read(tobeExtracted);
Embeded_img=Marked.coef_arrays{1,1};
Embeded_img=int16(Embeded_img);
for i=1:8:size(Embeded_img,1)
    for j=1:8:size(Embeded_img,2)
        Binary_array(end+1)=bitget(Embeded_img(i,j),1);
        %emb=bitset(Embeded_img(i,j),1,binary(loc));
        %Embeded_img(i,j)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i,j+1),1);
        %emb=bitset(Embeded_img(i,j+1),1,binary(loc));
        %Embeded_img(i,j+1)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i+1,j),1);
        %emb=bitset(Embeded_img(i+1,j),1,binary(loc));
        %Embeded_img(i+1,j)=emb;
        loc=loc+1;
        Binary_array(end+1)=bitget(Embeded_img(i+1,j+1),1);
        %emb=bitset(Embeded_img(i+1,j+1),1,binary(loc));
        %Embeded_img(i+1,j+1)=emb;
        loc=loc+1;
%         if loc>=len
%             flag=1;
%             break;
%         end
    end
%     if flag==1
%         break;
%     end
end
%将二进制字符串转化为ASCII
str_e = char(bin2dec(reshape(char(Binary_array+'0'), 8,[]).'))
%disp(str_e);
str_e=str_e';
ofid=fopen('DCT_LSBExtracted.txt','w');
fwrite(ofid,str_e,'uchar');
fclose(ofid);

end