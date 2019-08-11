function mat_marked=Visible_Embed(mat_image,mat_mark,option)
mat_image=imread(mat_image);
mat_image=rgb2gray(mat_image);
mat_mark=imread(mat_mark);
mat_mark=rgb2gray(mat_mark);
mat_marked=mat_image;
switch option
    case 1
        for i=1:size(mat_mark,1)
            for j=1:size(mat_mark,2)
                if(mat_mark(i,j)~=0)
                     mat_marked(i,j)=255-10*mat_mark(i,j);
                else
                    mat_marked(i,j)=mat_image(i,j);
                end
            end
        end
    case 2
        for i=1:size(mat_mark,1)
            for j=1:size(mat_mark,2)
                mat_marked(i,j)=uint8(mat_image(i,j))-mat_mark(i,j);
            end
        end
    case 3
         for i=1:size(mat_mark,1)
            for j=1:size(mat_mark,2)
                mat_marked(i,j)=uint8(mat_image(i,j))+uint8(0.04*mat_mark(i,j))*uint8(0.04*mat_image(i,j));
            end
        end
    otherwise
end
imwrite(mat_marked,'visibleMarked.bmp')
imwrite(mat_marked,'visibleMarked_show.bmp')
%imshow(mat_marked);
end