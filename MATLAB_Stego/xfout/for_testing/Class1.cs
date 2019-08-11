/*
* MATLAB Compiler: 6.2 (R2016a)
* Date: Sat Aug 10 13:35:16 2019
* Arguments: "-B" "macro_default" "-W" "dotnet:xfout,Class1,0.0,private" "-T" "link:lib"
* "-d" "C:\Users\msi-\Desktop\MATLAB_Stego\xfout\for_testing" "-v"
* "class{Class1:C:\Users\msi-\Desktop\MATLAB_Stego\xfout.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace xfout
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\msi-\Desktop\MATLAB_Stego\xfout.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Class1 : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static Class1()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "xfout.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Class1 class.
    /// </summary>
    public Class1()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Class1()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a void output, 0-input MWArrayinterface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    ///
    public void xfout()
    {
      mcr.EvaluateFunction(0, "xfout", new MWArray[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input MWArrayinterface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="imgmarked">Input argument #1</param>
    ///
    public void xfout(MWArray imgmarked)
    {
      mcr.EvaluateFunction(0, "xfout", imgmarked);
    }


    /// <summary>
    /// Provides a void output, 2-input MWArrayinterface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="imgmarked">Input argument #1</param>
    /// <param name="k">Input argument #2</param>
    ///
    public void xfout(MWArray imgmarked, MWArray k)
    {
      mcr.EvaluateFunction(0, "xfout", imgmarked, k);
    }


    /// <summary>
    /// Provides a void output, 3-input MWArrayinterface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="imgmarked">Input argument #1</param>
    /// <param name="k">Input argument #2</param>
    /// <param name="level">Input argument #3</param>
    ///
    public void xfout(MWArray imgmarked, MWArray k, MWArray level)
    {
      mcr.EvaluateFunction(0, "xfout", imgmarked, k, level);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] xfout(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "xfout", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imgmarked">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] xfout(int numArgsOut, MWArray imgmarked)
    {
      return mcr.EvaluateFunction(numArgsOut, "xfout", imgmarked);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imgmarked">Input argument #1</param>
    /// <param name="k">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] xfout(int numArgsOut, MWArray imgmarked, MWArray k)
    {
      return mcr.EvaluateFunction(numArgsOut, "xfout", imgmarked, k);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the xfout MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// k=8;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="imgmarked">Input argument #1</param>
    /// <param name="k">Input argument #2</param>
    /// <param name="level">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] xfout(int numArgsOut, MWArray imgmarked, MWArray k, MWArray level)
    {
      return mcr.EvaluateFunction(numArgsOut, "xfout", imgmarked, k, level);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
