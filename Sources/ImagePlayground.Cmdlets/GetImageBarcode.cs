using System.Management.Automation;
using System.IO;
using ImagePlayground;

namespace ImagePlayground.Cmdlets;
/// <summary>
/// This class is a PowerShell cmdlet that retrieves an image from a specified path.
/// </summary>
[OutputType(typeof(Image))]
[Cmdlet(VerbsCommon.Get, "ImageBarcode")]
public class GetImageBarcode : PSCmdlet
{
  [Parameter(
    Mandatory = true,
    Position = 0,
    ValueFromPipeline = true,
    ValueFromPipelineByPropertyName = true
  )]
  [ValidateNotNullOrEmpty]
  [Alias("FullName", "Path")]
  public string FilePath { get; set; }

  protected override void ProcessRecord()
  {
    FilePath = SessionState.Path.GetUnresolvedProviderPathFromPSPath(FilePath);
    if (!File.Exists(FilePath))
    {
      WriteError(new ErrorRecord(
        new FileNotFoundException($"File not found: {FilePath}"),
        "FileNotFound",
        ErrorCategory.ObjectNotFound,
        FilePath
      ));
      return;
    }
    WriteObject(BarCode.Read(FilePath));
  }
}
