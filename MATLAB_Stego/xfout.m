function xfout(imgmarked,k,level)
imgmarked=imread(imgmarked);
%k=8;
c=1;d=1;x=1;y=1;
[m,n]=size(imgmarked);
a=m/k;b=n/k;V=a*b;
Z=zeros(a,b);
for a1=1:a
  for i=c:c+k-1
    for a2=1:a
      for j=d:d+k-1
        Z(x,y)=QIM_OUT(imgmarked(i,j),level);
      end
         y=y+1;
         d=j+1;
    end
         d=1;y=1;
  end
         c=i+1;x=x+1;
end     
imwrite(Z,'ROBUST_ANTITRANSFORM_EXTRACT.bmp');
end
