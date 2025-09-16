namespace OrderService.Base;
public class ImageModel
{
    public byte[] Image { get; set; }
    public int ImageLength { get; set; }
    public string ImageContentType { get; set; }
    public ImageModel()
    {

    }
    public ImageModel(byte[] image, int imageLenght, string imageContentType)
    {
        Image = image;
        ImageLength = imageLenght;
        ImageContentType = imageContentType;
    }

    public void UploadPicture(byte[] image, string imageContentType)
    {
        const int maxBytes = 30 * 1024 * 1024; // 30 MB

        if (image == null || maxBytes == 0)
            throw new ArgumentException("Image cannot be empty");

        if (image.Length > maxBytes)
            throw new ArgumentException($"Image file is too large {maxBytes / (1024 * 1024)} MB");


        Image = image;
        ImageLength = image.Length;
        ImageContentType = imageContentType;
    }

    public void UploadProfilePicture(byte[] image, string imageContentType)
    {
        const int maxBytes = 15 * 1024 * 1024; // 15 MB

        if (image == null || maxBytes == 0)
            throw new ArgumentException("Image cannot be empty");

        if (image.Length > maxBytes)
            throw new ArgumentException($"Image file is too large {maxBytes / (1024 * 1024)} MB");


        Image = image;
        ImageLength = image.Length;
        ImageContentType = imageContentType;
    }
}
