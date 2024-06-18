using System;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsApplication1.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public FormBase m_FormBase;

            public FormBase FormBase
            {
                [DebuggerHidden]
                get
                {
                    m_FormBase = Create__Instance__(m_FormBase);
                    return m_FormBase;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_FormBase))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FormBase);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public FormParameter m_FormParameter;

            public FormParameter FormParameter
            {
                [DebuggerHidden]
                get
                {
                    m_FormParameter = Create__Instance__(m_FormParameter);
                    return m_FormParameter;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_FormParameter))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FormParameter);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public FormStart m_FormStart;

            public FormStart FormStart
            {
                [DebuggerHidden]
                get
                {
                    m_FormStart = Create__Instance__(m_FormStart);
                    return m_FormStart;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_FormStart))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_FormStart);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmPROP m_frmPROP;

            public frmPROP frmPROP
            {
                [DebuggerHidden]
                get
                {
                    m_frmPROP = Create__Instance__(m_frmPROP);
                    return m_frmPROP;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmPROP))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmPROP);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public MolDinamics m_MolDinamics;

            public MolDinamics MolDinamics
            {
                [DebuggerHidden]
                get
                {
                    m_MolDinamics = Create__Instance__(m_MolDinamics);
                    return m_MolDinamics;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MolDinamics))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MolDinamics);
                }
            }

        }


    }
}