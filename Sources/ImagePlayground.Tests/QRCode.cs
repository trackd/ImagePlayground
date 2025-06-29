using System.IO;
using Xunit;


namespace ImagePlayground.Tests {
    public partial class ImagePlayground {
        [Fact]
        public void Test_QRCodeUrl() {

            string filePath = System.IO.Path.Combine(_directoryWithImages, "QRCodeUrl.jpg");
            File.Delete(filePath);
            Assert.True(File.Exists(filePath) == false);

            QrCode.Generate("https://evotec.xyz", filePath);

            Assert.True(File.Exists(filePath) == true);

            var read = QrCode.Read(filePath);
            Assert.True(read.Message == "https://evotec.xyz");
        }

        [Fact]
        public void Test_QRCodeWiFi() {
            string filePath = System.IO.Path.Combine(_directoryWithImages, "QRCodeWiFi.png");
            File.Delete(filePath);
            Assert.True(File.Exists(filePath) == false);

            QrCode.GenerateWiFi("Evotec", "superHardPassword123!", filePath, true);

            Assert.True(File.Exists(filePath) == true);

            var read = QrCode.Read(filePath);
            Assert.True(read.Message == "WIFI:T:WPA;S:Evotec;P:superHardPassword123!;;");
        }

        [Fact]
        public void Test_BarCode() {
            string filePath = System.IO.Path.Combine(_directoryWithTests, "BarcodeEAN13.png");
            BarCode.Generate(BarCode.BarcodeTypes.EAN, "9012341234571", filePath);

            var read1 = BarCode.Read(filePath);
            Assert.True(read1.Message == "9012341234571");
            Assert.True(File.Exists(filePath) == true);

            filePath = System.IO.Path.Combine(_directoryWithTests, "BarcodeEAN7.png");
            BarCode.Generate(BarCode.BarcodeTypes.EAN, "96385074", filePath);
            Assert.True(File.Exists(filePath) == true);

            var read2 = BarCode.Read(filePath);
            Assert.True(read2.Message == "96385074");
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("pass123")]
        public void Test_QRCodeWiFi_Passwords(string password) {
            string filePath = System.IO.Path.Combine(_directoryWithImages, $"WiFi_{password}.png");
            File.Delete(filePath);
            Assert.True(File.Exists(filePath) == false);

            QrCode.GenerateWiFi("TestSSID", password, filePath, true);

            Assert.True(File.Exists(filePath) == true);

            var read = QrCode.Read(filePath);
            Assert.True(read.Message == $"WIFI:T:WPA;S:TestSSID;P:{password};;");
        }

        [Fact]
        public void Test_QRCodeIcon() {
            string filePath = System.IO.Path.Combine(_directoryWithImages, "QRCodeUrl.ico");
            File.Delete(filePath);
            Assert.True(File.Exists(filePath) == false);

            QrCode.Generate("https://evotec.xyz", filePath);

            Assert.True(File.Exists(filePath) == true);
        }
    }
}