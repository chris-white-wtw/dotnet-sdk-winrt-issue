using System;

namespace Objects
{
  /// <summary>
  /// Creates a class that calls the specified action in its Dispose method. 
  /// Typically used to replace
  /// try
  /// {
  /// }
  /// finally
  /// {
  ///   Cleanup();
  /// }
  /// 
  /// with
  /// using (new DisposableAction(() => Cleanup())
  /// {
  /// }
  /// </summary>
  public class DisposableAction : IDisposable
  {
    private Action mDisposeAction;
    public DisposableAction(Action disposeAction)
    {
      mDisposeAction = disposeAction;
    }

    public void Dispose()
    {
      if (mDisposeAction == null)
        return;
      Action disposeAction = mDisposeAction;
      mDisposeAction = null;
      disposeAction();
    }
  }
}
