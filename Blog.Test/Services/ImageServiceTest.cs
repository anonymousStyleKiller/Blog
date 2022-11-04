using Blog.Services.Implementations;

namespace Blog.Test.Services;

public class ImageServiceTest
{
  [Fact]
  public void CalculateOptimalSizeShouldReturnMinimumSizeWhenSizeThanAllowMinimum()
  {
    const int x = 10;
    const int y = 20;
    var imageSize = new ImageService(); 
    var (width, height) =  imageSize.CalculateOptimaSize(10,20);
    Assert.Equal((x, y), (width, height));
  }
}