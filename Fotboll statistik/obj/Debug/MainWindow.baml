   M S B A M L   `   `   `  ����L  HFotboll statistik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Fotboll_statistikFotboll_statistik  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   "    Fotboll_statistik.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Fotboll_statistik     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  
MainWindow��5	   	   $	��800��6   $
��1300��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5
       �� 
TargetType �� Property �� Value��%V   '��       �� 5   
   " ��6   .�5      ��  � ��$ Center=�6;   5      5      ��5      �� 5   
    �� ImageSource$ Bakgrundsbild.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ 
stackInput��5      $
��Left=�6)   $��
15,201,0,0q�6D   $	��Top=�6X   ��5      �� 5      	 �� Color$	 Black��6"   .+�5      � -   5        
 �Name$
 gridContainer��5      $��2q�6*   
������� � RowDefinitions 5      �� 5      �� 5      .+�5      � -   5        $
 	gridInput��5      $��0q�6*   
���   � � ColumnDefinitions 5      �� 5       �� 5!       5#      �� 5$      �� 5%      �� 5&      .+�5(      �� -   5         ��Name$ 	rectJonny��5(       
�������$��0,0,1,0q�6@   
���   �$��4��6`   $��0��6q   �� 5)      -   5        $ rectAdam��5)       
�������$��1,0,0,0q�6?   
���   �$��4��6_   $��0��6p   $��1��6�   �� 5*      -   5         ��Name$ lblJonny��5*      $��Jonnys resultat:��6.   $��0q�6I   $
��Bold"�6T   $��20(�6f   $��Center=�6t   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6�   Z� 6�   �� 5+      -   5        $ lblAdam��5+      $��Adams resultat:��6-   $��0q�6G   $
��Bold"�6R   $��20(�6d   $��1��6r   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6�   Z� 6�   �� 5,      -   5         ��Name$ 
comboJonny��5,      $	��0,5q�63   $��1��6@   $��Center=�6M    �� SelectedIndex$ 0��5-   h   $��20(�6z   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6   ��  �� Source 2   ,Fotboll_statistik.EnumBindingSourceExtension  *M� *
local:Team++6�   �� 5.      -	   5        $ 	comboAdam��5.      $	��0,5q�62   $��Center=�6?   $ 2��5/   Z   $��1��6l   $��1��6y   $��20(�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6   ��    *M� *
local:Team++6�   �� 50      -
   5         ��Name$ txtJonny��50      $��Center=�60   $	��0,5q�6M   $��2��6Z    �� TextWrapping$
 Wrap=�6g   $��0��6{   $	��120��6�   $��20(�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   �� 51      -   5        $ txtAdam��51      $��Center=�6/   $	��0,5q�6L   $��2��6Y   $
 Wrap=�6f   $��0��6z   $	��120��6�   $��20(�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��1��6�   52      � 53      -   5        $
 
gridButton��53      $	��0,5q�6+   $��1��68   .+�54      �� -   5         ��Name$ btnAdd��54      $��Lägg till resultat��6-   $��Center=�6J   $��0q�6g   $��Center=�6r   $��20(�6�   $��5q�6�   6�   55      56      57      �� 58   
   -   5         ��Name$ 
lstResults��58      $
��Left=�6'   $	��350��6B   $��790,163,0,0q�6O   $	��Top=�6d   $��Center=�6|   $��20(�6�    �� View 59      �� 5:      .P�5;      �� $��	  Datum  ��6%    �� DisplayMemberBinding 68   �� *Datum+�� 5<      $��	  Match  ��6%    68   �� *Match+�� 5=      $��	  Jonny  ��6%    68   �� *Jonny+�� 5>      $��  Adam  ��6%    67   �� *Adam+5?      5A      �� 5B   
   -   5         ��Name$ grpWinnings��5B      $��Vinststatistik��6(   $
��Left=�6@   $��
51,564,0,0q�6[   $	��Top=�6o   $��20(�6�   ���	#FF464646
�������.��5C      �� -   5        $ 
lstWinnigs��5C      $
��Left=�6+   $��10q�6F   $	��Top=�6R    5D      �� 5E      .P�5F      �� $��  Spelare  ��6)    6>   �� *	Spelare+�� 5G      $��  V  ��6)    68   �� *	Vinster+�� 5H      $��  F  ��6)    68   �� *
Förluster+�� 5I      $��  O  ��6)    68   �� *	Oavgjorda+�� 5J      $��  Vinstprocent  ��6)    6C   �� *Vinstprocent+�� 5K      $��  Vinster +/-  ��6)    6B   �� *Vinstdifferens+5L      5N      5O      �� 5P   
   -   5        $ grpGoals��5P      $��Målstatistik��6%   $
��Left=�6;   $��715,564,0,0q�6V   $	��Top=�6k   $��20(�6�   ���	#FF464646
�������.��5Q      �� -   5        $ lstGoals��5Q      $
��Left=�6)   $��10q�6D   $	��Top=�6P    5R      �� 5S      .P�5T      �� $��  Spelare  ��6)    6>   �� *	Spelare+�� 5U      $��  Gjorda mål  ��6)    6A   �� *Mål+�� 5V      $��  Mål +/-  ��6)    6>   �� *Måldifferens+�� 5W      $��  Mål per match  ��6)    6D   �� *
Genomsnitt+5X      5Z      5[      5]      5^      