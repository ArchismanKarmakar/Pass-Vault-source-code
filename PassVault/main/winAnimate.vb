Imports System
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Runtime.CompilerServices
Imports System.Text

Module winAnimate
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Animates the window from left to right. 
    '''' This flag can be used with roll or slide animation.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_HOR_POSITIVE As Integer = 0X1
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Animates the window from right to left. 
    '''' This flag can be used with roll or slide animation.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_HOR_NEGATIVE As Integer = 0X2
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Animates the window from top to bottom. 
    '''' This flag can be used with roll or slide animation.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_VER_POSITIVE As Integer = 0X4
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Animates the window from bottom to top. 
    '''' This flag can be used with roll or slide animation.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_VER_NEGATIVE As Integer = 0X8
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Makes the window appear to collapse inward 
    '''' if AW_HIDE is used or expand outward if the AW_HIDE is not used.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_CENTER As Integer = 0X10
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Hides the window. By default, the window is shown.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_HIDE As Integer = 0X10000
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Activates the window.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_ACTIVATE As Integer = 0X20000
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Uses slide animation. By default, roll animation is used.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_SLIDE As Integer = 0X40000
    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Uses a fade effect. 
    '''' This flag can be used only if hwnd is a top-level window.
    '''' <spanclass="code-SummaryComment"></summary></span>
    'Public Const AW_BLEND As Integer = 0X80000

    '''' <spanclass="code-SummaryComment"><summary></span>
    '''' Animates a window.
    '''' <spanclass="code-SummaryComment"></summary></span>
    '''' 



    Public Const AW_HOR_POSITIVE As Integer = &H1

    Public Const AW_HOR_NEGATIVE As Integer = &H2

    Public Const AW_VER_POSITIVE As Integer = &H4

    Public Const AW_VER_NEGATIVE As Integer = &H8

    Public Const AW_CENTER As Integer = &H10

    Public Const AW_HIDE As Integer = &H10000

    Public Const AW_ACTIVATE As Integer = &H20000

    Public Const AW_SLIDE As Integer = &H40000

    Public Const AW_BLEND As Integer = &H80000


    Public Const AW_BLEND_INT As Integer = &H80000
    Public Const AW_HIDE_INT As Integer = &H10000
    Public Const AW_SLIDE_INT As Integer = &H40000
    Public Const AW_CENTER_INT As Integer = &H10
    Public Const AW_ACTIVATE_INT As Integer = &H20000
    Public Const AW_HOR_POSITIVE_INT As Integer = &H1
    Public Const AW_HOR_NEGATIVE_INT As Integer = &H2
    Public Const AW_VER_POSITIVE_INT As Integer = &H4
    Public Const AW_VER_NEGATIVE_INT As Integer = &H8
    '<DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Declare Function AnimateWindow Lib "user32" (ByVal hwand As Int32, ByVal dwTime As Int32, ByVal dwFlags As Int32) As Boolean
    'End Function
End Module
