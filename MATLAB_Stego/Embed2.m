function B=Embed2(img1,ifid,len,ii,jj,seed)
ifid=fopen(ifid,'r');
L=64;c=1;d=1;e=0;j1=1;k=0;

img1=imread(img1);
img=img1;
%a=stren;%水印强度
B=zeros(1,len);
B(1)=seed;
M=[];
times=1;
for i=1:len-1
    B(i+1)=3.57*B(i)*(1-B(i));
end
for j=1:len
    if B(j)<0.5
        B(j)=0;
    else
        B(j)=1;
    end
end
i1=size(img,1);
j1=size(img,2);
i2=1;
j2=1;
flag=0;
strbin=[];
while ~feof(ifid) %判断是否为文件的结尾
   %A =fread(ifid,1,'ubit1');

   % Z=repelem(A,80);%过采样
   % C=xor(B,Z);
   strbin=[];
   
    M=fread(ifid,1,'ubit8');
    
    if isempty(M)
        break;
    end
    for i=1:8
       A=bitget( M(1),8+1-i);
       strbin(end+1)=A;
       Z=repelem(A,len);
       C=xor(B,Z);
       for k_t=1:len
            if j2>j1
                j2=1;
                i2=i2+ii;
            end
            if (i2>i1)
                 flag=1;
            end
           
            if i2+j2>=i1*i1
                flag=1;
            end
            img(i2,j2)=QIM(img(i2,j2),10,C(k_t));
%             img(i2,j2)=img(i2,j2)+a*C(k_t);
            j2=j2+jj;
            times=times+1;
       end
       if flag==1
           break;
       end
    end
    if flag==1
        break;
    end
end
   % fwrite(ofid,A,'char');

imwrite(img,'ROBUST_QIM.bmp');%保存加入水印后的图片

fclose(ifid);
%fclose(ofid);
end