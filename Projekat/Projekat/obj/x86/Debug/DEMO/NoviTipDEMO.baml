   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   C ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat.TipProjekat.Tip 5   	      Projekat.DEMO.NoviTipDEMO   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   1
validationclr-namespace:Projekat.Tip     5   	     � Icon$)  #/Projekat;component/Images/demo.png��5   	    � Title$ Novi tip DEMO��5   	   $	��411��6   $	��412��6,   $	��411��68   $	��412��6H    � WindowStartupLocation$ CenterScreen=�6W   .��5      �  � RowDefinitions 5	   
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
20,3,27,20q�6Z   .+�5      �� $��'Esc' - za izlaz��6   �� 5      -   5        $��Pomoć��5      $��3,3,0,3q�6%   $��90��66   $��90��6D   $��2,2,2,2q�6R   6d   5      �� 5   
   $��Oznaka:��6   $��0��6"   $��1��62   $��Center=�6?   $��20,0,0,0q�6\   (   "Xceed.Wpf.Toolkit.WatermarkTextBox  5    
   -   5        $��	txtOznaka��5        $��1��61   $��1��6A   $��
20,3,27,20q�6N      	Watermark$ Unesite oznaku��6c   .��6   ��5!      �� 5"       �� Path$ 
Tip.Oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�6,   	 �� ValidationRules	 5#        Projekat.Tip.ValidacijaTip  5$      ,  &System.Windows.Controls.ValidationRule
   ValidationStep$
 RawProposedValue=�63   !  Projekat.Tip.ValidacijaTip2  5%      $
 RawProposedValue=�64   5'      .��5(   *    =� ErrorTemplate 5*      �� 5+      .R�5,      �� $��0,25,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5-      .��5.   (   5/      �� 51   
   $
��Ime:��6   $��0��6   $��2��6/   $��Center=�6=   $��20,0,0,0q�6Z     53   
   -   5        $��txtIme��53       $��1��6.   $��2��6>   $��
20,3,27,20q�6K   $ Unesite ime��6_   .��6x   ��54      �� 55      $ Tip.Ime�6   $ PropertyChanged=�6)   	 56      !  Projekat.Tip.ValidacijaTip3  57      $
 RawProposedValue=�64   59      .��5:   *    5<      �� 5=      .R�5>      �� $��0,25,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5?      .��5@   (   5A      �� 5C   
   $��Ikonica:��6   $��0��6#   $��3��63   $��Center=�6@   $��20,0,0,0q�6]   � 5D   
   $��1��6   $��3��6   $��
20,3,27,20q�6,    5E      �� 5F      $��85 �6#   �� 5G      $	��168 �6#   �� 5H      $��2* �6#   .+�5J      �� $��1q�6   
���   �$��56��6=   $��3,5,10,5q�6I   ._�5K      �� -   5        $��Ikonica��5K      $��49��6'   $��62��63   $
��Fill=�6>   ��5L      �� 5M      $ Tip.Ikonica�6"   67   5O      5P      �� 5Q      -   5        $��Dodaj ikonicu��5Q      $��	1,5,65,39q�6F   $��22��6Y   $��93��6e   $��1��6p   5R      �� 5T   
   $��Opis:��6   $��0��6    $��4��60   $��Center=�6=   $��20,0,0,0q�6Z     5V   
   -   5        $��txtOpis��5V       $��1��6/   $��4��6?    �� TextWrapping$
 Wrap=�6L   $
��Auto=�6`   $��
20,3,27,30q�6�   $ Unesite opis . . .��6�   .��6�   ��5W      �� 5X      $ Tip.Opis�6   $ PropertyChanged=�6*   	 5Y      !  Projekat.Tip.ValidacijaTip4  5Z      $
 RawProposedValue=�64   5\      .��5]   *    5_      �� 5`      .R�5a      �� $��0,48,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5b      .��5c   (   5d      � 5f   
   $��5��6   $��1��6!   $ 
Horizontal=�61   $��Right=�6J   $��0,3,27,0q�6f   $	��190��6x   .+�5g      �� -   5        $��3,3,3,3q�5g      $��Sačuvaj��6&   $��3q�6Q   $��90��6^   ��5h      �� 5i       �� 
TargetType" ��6   .�5j      ��  �� Property � {� �� Value .  66    �� Triggers 5k      ^� 5l       ^� 
Conditions 5m   "   �� 5n   &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ 	txtOznaka�� �� Value	 False6v   �� 5o   &    60   �� $ (Validation.HasError)�$ txtIme��	 False6s   �� 5p   &    60   �� $ (Validation.HasError)�$ txtOpis��	 False6t   .0�5r   "   ��  � {� . 6>   5s      5u      5w      �� 5x      -   5        $��3,3,0,3q�5x      $��Odustani��6&   $��3q�6S   $��90��6_    �� IsCancel . 6j   5y      5z      5{      