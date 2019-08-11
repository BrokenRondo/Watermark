/*
* MATLAB Compiler: 6.2 (R2016a)
* Date: Sat Aug 10 10:47:09 2019
* Arguments: "-B" "macro_default" "-W" "dotnet:Embed2,Class1,0.0,private" "-T" "link:lib"
* "-d" "C:\Users\msi-\Desktop\MATLAB_Stego\Embed2\for_testing" "-v"
* "class{Class1:C:\Users\msi-\Desktop\MATLAB_Stego\Embed2.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace Embed2
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\msi-\Desktop\MATLAB_Stego\Embed2.m
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

          string ctfFileName = "Embed2.ctf";

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
    /// Provides a single output, 0-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2()
    {
      return mcr.EvaluateFunction("Embed2", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1)
    {
      return mcr.EvaluateFunction("Embed2", img1);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1, MWArray ifid)
    {
      return mcr.EvaluateFunction("Embed2", img1, ifid);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1, MWArray ifid, MWArray len)
    {
      return mcr.EvaluateFunction("Embed2", img1, ifid, len);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1, MWArray ifid, MWArray len, MWArray ii)
    {
      return mcr.EvaluateFunction("Embed2", img1, ifid, len, ii);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <param name="jj">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1, MWArray ifid, MWArray len, MWArray ii, MWArray jj)
    {
      return mcr.EvaluateFunction("Embed2", img1, ifid, len, ii, jj);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <param name="jj">Input argument #5</param>
    /// <param name="seed">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Embed2(MWArray img1, MWArray ifid, MWArray len, MWArray ii, MWArray 
                    jj, MWArray seed)
    {
      return mcr.EvaluateFunction("Embed2", img1, ifid, len, ii, jj, seed);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1, MWArray ifid)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1, ifid);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1, MWArray ifid, MWArray len)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1, ifid, len);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1, MWArray ifid, MWArray len, 
                      MWArray ii)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1, ifid, len, ii);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <param name="jj">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1, MWArray ifid, MWArray len, 
                      MWArray ii, MWArray jj)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1, ifid, len, ii, jj);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the Embed2 MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="img1">Input argument #1</param>
    /// <param name="ifid">Input argument #2</param>
    /// <param name="len">Input argument #3</param>
    /// <param name="ii">Input argument #4</param>
    /// <param name="jj">Input argument #5</param>
    /// <param name="seed">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Embed2(int numArgsOut, MWArray img1, MWArray ifid, MWArray len, 
                      MWArray ii, MWArray jj, MWArray seed)
    {
      return mcr.EvaluateFunction(numArgsOut, "Embed2", img1, ifid, len, ii, jj, seed);
    }


    /// <summary>
    /// Provides an interface for the Embed2 function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// a=stren;  水印强度
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void Embed2(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("Embed2", numArgsOut, ref argsOut, argsIn);
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
