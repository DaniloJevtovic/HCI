   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   C ?Projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Projekat.EtiketaProjekat.Etiketa 5   	   #   Projekat.Etiketa.NovaEtiketa1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Kxctk:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   5
validationclr-namespace:Projekat.Etiketa     5   	     � Icon$(  "/Projekat;component/Images/tag.png��5   	    � Title$ Nova etiketa��5   	   $	��312��6   $	��412��6+   $	��313��67   $	��412��6G    � WindowStartupLocation$ CenterScreen=�6V   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��80 �6   �� 5      $��32 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��77 �6   �� 5      $
��240* �6   .+�5   
   � $��1��6    � Orientation$ 
Horizontal=�6%   $��Right=�6>   $��
20,3,27,20q�6Z   .+�5      �� -   5        $��Pomoć��5      $��3,3,0,3q�6%   $��90��66   $��90��6D   $��2,2,2,2q�6R   6d   5      �� 5   
   $��Oznaka:��6   $��0��6"   $��1��62   $��Center=�6?   $��20,0,0,0q�6\   (   "Xceed.Wpf.Toolkit.WatermarkTextBox  5   
   -   5        $��	txtOznaka��5       $��1��61   $��1��6A   $��
20,3,27,20q�6N      	Watermark$ Unesite oznaku��6b   .��6~   ��5      �� 5        �� Path$ Etiketa.Oznaka�6    �� UpdateSourceTrigger$ PropertyChanged=�60   	 �� ValidationRules	 5!      ! Projekat.Etiketa.Validacija  5"      ,  &System.Windows.Controls.ValidationRule
   ValidationStep$
 RawProposedValue=�60   "  Projekat.Etiketa.Validacija2  5#      $
 RawProposedValue=�61   5%      .��5&   *    =� ErrorTemplate 5(      �� 5)      .R�5*      �� $��0,25,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5+      .��5,   (   5.      �� 51   
   $��Boja:��6   $��0��6    $��2��60   $��Center=�6=   $��20,0,0,0q�6Z   �� 52   
   -   5        $��cmBoja��52      $��1��6!   $��2��61   $��
20,3,27,20q�6>    �� Text 6S   �� $ Etiketa.Boja�$ PropertyChanged=�.@�53      �� $��crvena��6   6.   �� 54      $
��crna��6   6,   �� 55      $��plava��6   6-   �� 56      $��žuta��6   6,   �� 57      $��bijela��6   6.   �� 58      $��zelena��6   6.   �� 59      $��smedja��6   6.   �� 5:      $��
lubičasta��6   61   �� 5;      $��narandzasta��6   63   �� 5<      $
��siva��6   6,   5=      �� 5@   
   $��Opis:��6   $��0��6    $��3��60   $��Center=�6=   $��20,0,0,0q�6Z     5A   
   -   5        $��txtOpis��5A       $��1��6/   $��3��6?   $��
20,3,27,30q�6L   $ Unesite opis . . .��6`    �� TextWrapping$
 Wrap=�6   $
��Auto=�6�   .��6�   ��5B      �� 5C      $ Etiketa.Opis�6   $ PropertyChanged=�6.   	 5D      "  Projekat.Etiketa.Validacija3  5E      $
 RawProposedValue=�61   5G      .��5H   *    5J      �� 5K      .R�5L      �� $��0,48,0,0q�6C   
�������
���   ���6    �� *[0].ErrorContent+6h   5M      .��5N   (   5P      � 5S   
   $��4��6   $��1��6!   $ 
Horizontal=�61   $��Right=�6J   $��0,3,27,0q�6f   $	��190��6x   .+�5T      �� -   5        $��3,3,3,3q�5T      $��Sačuvaj��6&   $��3q�6Q   $��90��6^   ��5U      �� 5V       �� 
TargetType" ��6   .�5W      ��  �� Property � {� �� Value .  66    �� Triggers 5X      ^� 5Y       ^� 
Conditions 5Z   "   �� 5[   &    �� Binding 60   �� $ (Validation.HasError)� �� ElementName$ 	txtOznaka�� �� Value	 False6v   �� 5\   &    60   �� $ (Validation.HasError)�$ txtOpis��	 False6t   .0�5^   "   ��  � {� . 6>   5_      5a      5c      �� 5d      -   5        $��3,3,0,3q�5d      $��Odustani��6&   $��3q�6S   $��90��6_   5e      5f      5g      