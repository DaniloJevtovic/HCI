   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   C ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat.TipProjekat.Tip 5   	      Projekat.Tip.NoviTip1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   1
validationclr-namespace:Projekat.Tip     5   	     � Icon$(  "/Projekat;component/Images/tip.png��5   	    � Title$ Novi tip��5   	   $	��411��6   $	��412��6'   $	��411��63   $	��412��6C    � WindowStartupLocation$ CenterScreen=�6R   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��80 �6   �� 5      $
��Auto �6   �� 5      $	��86* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��347* �6   .+�5   
   � $��1��6    � Orientation$ 
Horizontal=�6%   $��Right=�6>   $��
20,3,27,20q�6Z   .+�5      �� -   5        $��Pomoć��5      $��3,3,0,3q�6%   $��90��66   $��90��6D   $��2,2,2,2q�6R   6d   5      �� 5   
   $��Oznaka:��6   $��0��6"   $��1��62   $��Center=�6?   $��20,0,0,0q�6\   (   "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5        $��	txtOznaka��5       $��1��61   $��1��6A   $��
20,3,27,20q�6N      	Watermark$ Unesite oznaku��6c   .��6   ��5       �� 5!       �� Path$ 
Tip.Oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�6,   	 �� ValidationRules	 5"        Projekat.Tip.ValidacijaTip  5#      ,  &System.Windows.Controls.ValidationRule
   ValidationStep$
 RawProposedValue=�63   !  Projekat.Tip.ValidacijaTip2  5$      $
 RawProposedValue=�64   5&      .��5'   *    =� ErrorTemplate 5)      �� 5*      .R�5+      �� $��0,25,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5,      .��5-   (   5.      �� 50   
   $
��Ime:��6   $��0��6   $��2��6/   $��Center=�6=   $��20,0,0,0q�6Z     52   
   -   5        $��txtIme��52       $��1��6.   $��2��6>   $��
20,3,27,20q�6K   $ Unesite ime��6_   .��6x   ��53      �� 54      $ Tip.Ime�6   $ PropertyChanged=�6)   	 55      !  Projekat.Tip.ValidacijaTip3  56      $
 RawProposedValue=�64   58      .��59   *    5;      �� 5<      .R�5=      �� $��0,25,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5>      .��5?   (   5@      �� 5B   
   $��Ikonica:��6   $��0��6#   $��3��63   $��Center=�6@   $��20,0,0,0q�6]   � 5C   
   $��1��6   $��3��6   $��
20,3,27,20q�6,    5D      �� 5E      $��85 �6#   �� 5F      $	��168 �6#   �� 5G      $��2* �6#   .+�5I      �� $��1q�6   
���   �$��56��6=   $��3,5,10,5q�6I   ._�5J      �� -   5        $��Ikonica��5J      $��49��6'   $��62��63   $
��Fill=�6>   ��5K      �� 5L      $ Tip.Ikonica�6"   67   5N      5O      �� 5P      -   5        $��Dodaj ikonicu��5P      $��	1,5,65,39q�6F   $��22��6Y   $��93��6e   $��1��6p   5Q      �� 5S   
   $��Opis:��6   $��0��6    $��4��60   $��Center=�6=   $��20,0,0,0q�6Z     5U   
   -   5        $��txtOpis��5U       $��1��6/   $��4��6?    �� TextWrapping$
 Wrap=�6L   $
��Auto=�6`   $��
20,3,27,30q�6�   $ Unesite opis . . .��6�   .��6�   ��5V      �� 5W      $ Tip.Opis�6   $ PropertyChanged=�6*   	 5X      !  Projekat.Tip.ValidacijaTip4  5Y      $
 RawProposedValue=�64   5[      .��5\   *    5^      �� 5_      .R�5`      �� $��0,48,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5a      .��5b   (   5c      � 5e   
   $��5��6   $��1��6!   $ 
Horizontal=�61   $��Right=�6J   $��0,3,27,0q�6f   $	��190��6x   .+�5f      �� -   5        $��3,3,3,3q�5f      $��Sačuvaj��6&   $��3q�6Q   $��90��6^   ��5g      �� 5h       �� 
TargetType" ��6   .�5i      ��  �� Property � {� �� Value .  66    �� Triggers 5j      ^� 5k       ^� 
Conditions 5l   "   �� 5m   &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ 	txtOznaka�� �� Value	 False6v   �� 5n   &    60   �� $ (Validation.HasError)�$ txtIme��	 False6s   �� 5o   &    60   �� $ (Validation.HasError)�$ txtOpis��	 False6t   .0�5q   "   ��  � {� . 6>   5r      5t      5v      �� 5w      -   5        $��3,3,0,3q�5w      $��Odustani��6&   $��3q�6S   $��90��6_   5x      5y      5z      