using System;
using Objects;

namespace Progress
{
  public static class ProgressExtensions
  {
    private static Action<SystemException> sHandleProgressException;

    /// <remarks>Only intended for use in tests.</remarks>
    public static IDisposable WithExceptionHandler(Action<SystemException> handler)
    {
      Action<SystemException> prev;
      (sHandleProgressException, prev) = (handler, sHandleProgressException);
      return new DisposableAction(() => sHandleProgressException = prev);
    }
 }
}