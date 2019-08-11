function xfin(inputcover,inputmark,k,level)
inputcover=imread(inputcover);
inputmark=imread(inputmark);
%k=8;
c=1;d=1;x=1;y=1;
[m,n]=size(inputcover);
a=m/k;b=n/k;V=a*b;
reimgw=imresize(inputmark,[a,b]);
%imwrite(reimgw,'ROBUST_ANTITRANSFORM.bmp');
for a1=1:a
  for i=c:c+k-1
    for a2=1:b
      for j=d:d+k-1
        inputcover(i,j)=QIM(inputcover(i,j),level,reimgw(x,y));
      end
         y=y+1;
         d=j+1;
    end
         d=1;y=1;
  end
         c=i+1;x=x+1;
end           
imwrite(inputcover,'ROBUST_ANTITRANSFORM.bmp');

end
        