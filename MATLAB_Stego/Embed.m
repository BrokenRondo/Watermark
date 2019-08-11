function Embed(img1,ifid,stren,len1,ii,jj,logistic)
%ofid=fopen(ofid,'w');
ifid=fopen(ifid,'r');
L=64;c=1;d=1;e=0;j1=1;k=0;
len=len1;
img1=imread(img1);
img=img1;
a=stren;%水印强度
B=zeros(1,len);
B(1)=logistic;
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
while ~feof(ifid) %判断是否为文件的结尾
    %A =fread(ifid,1,'ubit1');

   % Z=repelem(A,80);%过采样
   % C=xor(B,Z);
    M=fread(ifid,1,'ubit8');
    if isempty(M)
        break;
    end
    for i=1:8
       A=bitget( M(1),8+1-i);
       Z=repelem(A,len1)
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
            img(i2,j2)=img(i2,j2)+a*C(k_t);
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

imwrite(img,'SSEmbeded.bmp');%保存加入水印后的图片
% imgm=junzhilvbo(img,1);
% imwrite(imgm,'lena_lvbo.bmp');
% imresize(img,0.1);
% imwrite(img,'kuopin_changed1.bmp');
% img_chan=imread('kuopin_changed1.bmp');
% imresize(img_chan,10);
% imwrite(img_chan,'kuopin_change.bmp');
fclose(ifid);
%fclose(ofid);
end