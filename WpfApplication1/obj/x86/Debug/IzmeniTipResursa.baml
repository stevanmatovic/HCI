   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   &     WpfApplication1.IzmeniTipResursa   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  IzmeniTipLokala��5   	   $	��359��6!   "   WpfApplication1.HelpProvider   HelpKey$ Forma��6.   $	��609��6Q   
����  � � 
ResizeMode$ NoResize=�6p   
������� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5	      � $	��291��6   $	��583��6    � ColumnDefinitions 5
   
   �� 5      $
��242* �6   �� 5      $
��242* �6    � RowDefinitions 5   
   �� 5      $	��38* �6   �� 5      $	��38* �6   �� 5      $	��58* �6   �� 5      $
��121* �6   �� 5      $	��38* �6   .+�5   
   �� -   5        $��label1��5   g   $��Unesite naziv tipa:��6   $��28��6.   $
��Left=�6:   $��12,0,0,0q�6U   $	��Top=�6u   $��1��6�   �� 5   
   -   5        $��label2��5   j   $��Ucitajte sliku za tip:��6   $��28��61   $
��Left=�6=   $��12,0,0,0q�6X   $	��Top=�6x   $��2��6�   �� 5   
   -   5        $��label3��5   g   $��Unesite opis tipa:��6   $��28��6-   $
��Left=�69   $��	12,24,0,0q�6T   $	��Top=�6u   $��3��6�   �� 5   
   -   5        $��label4��5   t   $&�� Unesite jedinstvenu oznaku tipa:��6   $��28��6;   $
��Left=�6G   $��12,0,0,0q�6b   $	��Top=�6�   �� 5   
   -   5        $��	idTipaLok��5   l   $��1��6   $��23��6"   $
��Left=�6.   $��0,2,0,0q�6I    �� 
IsReadOnly . $	��Top=�6}   $	��278��6�   ��6�   ��  �� Path$ ID�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5   
   -   5        $��nazivTipaLok��5   g   $��1��6   $��1��6"   $��23��6/   $
��Left=�6;   $��0,2,0,0q�6V   $	��Top=�6{   $	��278��6�   $ IzmeniImeTipa��6�   ��6�   �� $	 Ime�$	 PropertyChanged=�6�   �� 5   
   -   5        $��slikaTipChooser��5   �   $��Izaberite sliku ovde..��6   $��1��62   $��2��6B   $��23��6O   $
��Left=�6[   $��
100,15,0,0q�6v   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -	   5        $��opisTipaLok��5   K   $��89��6   $
��Left=�6   $��0,24,0,0q�69   $	��Top=�6^   $	��278��6v   $��1��6�   $��3��6�   $ IzmeniOpisTipa��6�   ��6�   �� $
 Opis�$	 PropertyChanged=�6�   �� 5   
   -
   5        $��
sacuvajTip��5   k   $��Sačuvaj��6   $��4��6#   $��25��60   $
��Left=�6<   $��
188,10,0,0q�6W   $	��Top=�6}   $��90��6�   
 �� 	IsDefault
 . $��1��6�   �� 5   
   -   5        $��button2��5   |   $��	Odustanak��6   $��1��6%   $��4��65   $��23��6B   $
��Left=�6N   $��	89,10,0,0q�6i   $	��Top=�6�   $��75��6�    �� IsCancel . 6�   �� 5   
   $��1q�6   6'   �� 5    
   -   5        $��ucitanaSlikaTipa��5    7   $��53��6   $
��Left=�6   $
��Fill=�6O   $	��Top=�6^   $��64��6v   $��1��6�   $��2��6�   �� 5!   
   -   5        $��border1��5!   b   ���#315b7d$��1q�6'   $��54��6;   $
��Left=�6G   $	��Top=�6q   $��64��6�   $��1��6�   $��2��6�   $��1,1,0,0q�6�   5"      5#      