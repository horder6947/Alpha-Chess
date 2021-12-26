Imports System.Math, System.Media

Public Class Form1

    'Pawn: 1 & (Pawn Number)
    'Rook: 2 & (Rook Number)
    'Knight: 3 & (Knight Number)
    'Bishop: 4 & (Bishop Number)
    'Queen: 5 & (Queen Number)
    'King: 6
    'Rookie: 7 & (Rookie Number)

    Public TempLocation As Point

    Public WhiteM As Integer = Form2.PlayerTimer
    Public WhiteS As Integer

    Public BlackM As Integer = Form2.PlayerTimer
    Public BlackS As Integer

    Public WhiteQATTC As Integer = Form2.QAT
    Public BlackQATTC As Integer = Form2.QAT

    Public NumberOfWhitePawns As Integer = 8
    Public NumberOfBlackPawns As Integer = 8

    Public ShortCastleWhite As Boolean = True
    Public LongCastleWhite As Boolean = True
    Public ShortCastleBlack As Boolean = True
    Public LongCastleBlack As Boolean = True

    Public KingsExCooldownWhite As Integer = 7
    Public KingsExCooldownBlack As Integer = 7
    Public KingsExStatusWhite As Boolean = False
    Public KingsExStatusBlack As Boolean = False

    Public TakeWhiteKnight1Elig(72) As Boolean
    Public TakeWhiteKnight2Elig(72) As Boolean
    Public TakeWhiteKnight3Elig(72) As Boolean
    Public TakeBlackKnight1Elig(72) As Boolean
    Public TakeBlackKnight2Elig(72) As Boolean
    Public TakeBlackKnight3Elig(72) As Boolean

    Public WhiteQueen1Alive As Boolean = True
    Public BlackQueen1Alive As Boolean = True
    Public QueensAdvRow As Integer
    Public QueensAdvClmns(8) As Integer
    Public ParalysedWhiteQueen(2) As Boolean
    Public ParalysedBlackQueen(2) As Boolean

    Public SeventyFiveMoveRule As Integer = 75

    Public EnPassantWhitePawn(8) As Boolean
    Public EnPassantBlackPawn(8) As Boolean

    Public LastTakenPieceWhite As PictureBox
    Public LastTakenPieceBlack As PictureBox
    Public WhitePiecesTaken As Integer = 0
    Public BlackPiecesTaken As Integer = 0
    Public WhiteTurn As Boolean = True

    Public SelectedPiece As Integer
    Public Board(,) As Integer = {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, -21, -31, -41, -51, -60, -42, -32, -22, 0},
                                  {0, 0, -11, -12, -13, -14, -15, -16, -17, -18, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 11, 12, 13, 14, 15, 16, 17, 18, 0},
                                  {0, 0, 21, 31, 41, 51, 60, 42, 32, 22, 0}}

    Public BishopsRageElig As Boolean

    Public MoveSound As New SoundPlayer(My.Resources.Move)
    Public TakeSound As New SoundPlayer(My.Resources.Take1)
    Public GameStartsSound As New SoundPlayer(My.Resources.Game_Starts)
    Public GameEndsSound As New SoundPlayer(My.Resources.Game_Ends)
    Public BishopsRageSound As New SoundPlayer(My.Resources.Bishop_s_Rage)
    Public MainEntranceSound As New SoundPlayer(My.Resources.Main_Entrance)
    Public PromotionSound As New SoundPlayer(My.Resources.Promotion)
    Public CastleSound As New SoundPlayer(My.Resources.Castle)
    Public QueensAdCycleSound As New SoundPlayer(My.Resources.Queen_sAdvantageCycle)

    Public Random As New Random
    Public Temp1 As Integer
    Public Temp2 As Integer
    Public Temp3 As Integer
    Public RandomNumber As Integer = Random.Next(9, 15)

    'Loading the Form

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GameStartsSound.Play()

        Form2.Hide()

        If Form2.PlayerTimerCB.SelectedItem <> "No Time" Then

            If Form2.PlayerTimer > 9 Then

                Label8.Text = Form2.PlayerTimer & ":00"
                Label14.Text = Form2.PlayerTimer & ":00"

            Else

                Label8.Text = "0" & Form2.PlayerTimer & ":00"
                Label14.Text = "0" & Form2.PlayerTimer & ":00"

            End If

        End If

        Select Case Form2.BoardCB.SelectedItem

            Case "Blue"

                Me.BackgroundImage = My.Resources.Blue_Background

            Case "Brown"

                Me.BackgroundImage = My.Resources.Brown_Background

            Case "Orange"

                Me.BackgroundImage = My.Resources.Orange_Background

            Case "Purple"

                Me.BackgroundImage = My.Resources.Purple_Background

            Case "Pink"

                Me.BackgroundImage = My.Resources.Pink_Background

            Case "Red"

                Me.BackgroundImage = My.Resources.Red_Background

            Case "Grey"

                Me.BackgroundImage = My.Resources.Grey_Background

            Case "Metal"

                Me.BackgroundImage = My.Resources.Metal_Background

            Case "Newspaper"

                Me.BackgroundImage = My.Resources.Newspaper_Background

            Case "Walnut"

                Me.BackgroundImage = My.Resources.Walnut_Background

            Case "Blurred Wood"

                Me.BackgroundImage = My.Resources.Blurred_Wood_Background

        End Select

        Select Case Form2.PiecesStyleCB.SelectedItem

            Case "Classic"

                Call ClassicPieces()

                Icon = My.Resources.Black_King_Classic1

            Case "Neo-Wood"

                Call NeoWoodPieces()

                Icon = My.Resources.Hooded_White_Knight1

            Case "Neo"

                Icon = My.Resources.White_Rookie_Neo1

                Call NeoPieces()

        End Select

        Call ResetTakeWhiteKnightElig()
        Call ResetTakeBlackKnightElig()

    End Sub

    Public Sub ClassicPieces()

        WhitePawn1.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn2.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn3.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn4.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn5.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn6.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn7.BackgroundImage = My.Resources.White_Pawn_Classic
        WhitePawn8.BackgroundImage = My.Resources.White_Pawn_Classic
        WhiteRook1.BackgroundImage = My.Resources.White_Rook_Classic
        WhiteRook2.BackgroundImage = My.Resources.White_Rook_Classic
        WhiteKnight1.BackgroundImage = My.Resources.White_Knight_Classic
        WhiteKnight2.BackgroundImage = My.Resources.White_Knight_Classic
        WhiteKnight3.BackgroundImage = My.Resources.White_Knight_Classic
        WhiteBishop1.BackgroundImage = My.Resources.White_Bishop_Classic
        WhiteBishop2.BackgroundImage = My.Resources.White_Bishop_Classic
        WhiteQueen1.BackgroundImage = My.Resources.White_Queen_Classic
        WhiteQueen2.BackgroundImage = My.Resources.White_Queen_Classic
        WhiteKing.BackgroundImage = My.Resources.White_King_CLassic
        WhiteRookie1.BackgroundImage = My.Resources.White_Rookie_Classic
        WhiteRookie2.BackgroundImage = My.Resources.White_Rookie_Classic

        WhitePawn1.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn2.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn3.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn4.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn5.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn6.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn7.InitialImage = My.Resources.White_Pawn_Classic
        WhitePawn8.InitialImage = My.Resources.White_Pawn_Classic
        WhiteRook1.InitialImage = My.Resources.White_Rook_Classic
        WhiteRook2.InitialImage = My.Resources.White_Rook_Classic
        WhiteKnight1.InitialImage = My.Resources.White_Knight_Classic
        WhiteKnight2.InitialImage = My.Resources.White_Knight_Classic
        WhiteKnight3.InitialImage = My.Resources.White_Knight_Classic
        WhiteBishop1.InitialImage = My.Resources.White_Bishop_Classic
        WhiteBishop2.InitialImage = My.Resources.White_Bishop_Classic
        WhiteQueen1.InitialImage = My.Resources.White_Queen_Classic
        WhiteQueen2.InitialImage = My.Resources.White_Queen_Classic
        WhiteKing.InitialImage = My.Resources.White_King_CLassic
        WhiteRookie1.InitialImage = My.Resources.White_Rookie_Classic
        WhiteRookie2.InitialImage = My.Resources.White_Rookie_Classic



        BlackPawn1.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn2.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn3.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn4.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn5.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn6.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn7.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackPawn8.BackgroundImage = My.Resources.Black_Pawn_Classic
        BlackRook1.BackgroundImage = My.Resources.Black_Rook_Classic
        BlackRook2.BackgroundImage = My.Resources.Black_Rook_Classic
        BlackKnight1.BackgroundImage = My.Resources.Black_Knight_Classic
        BlackKnight2.BackgroundImage = My.Resources.Black_Knight_Classic
        BlackKnight3.BackgroundImage = My.Resources.Black_Knight_Classic
        BlackBishop1.BackgroundImage = My.Resources.Black_Bishop_Classic
        BlackBishop2.BackgroundImage = My.Resources.Black_Bishop_Classic
        BlackQueen1.BackgroundImage = My.Resources.Black_Queen_Classic
        BlackQueen2.BackgroundImage = My.Resources.Black_Queen_Classic
        BlackKing.BackgroundImage = My.Resources.Black_King_Classic
        BlackRookie1.BackgroundImage = My.Resources.Black_Rookie_Classic
        BlackRookie2.BackgroundImage = My.Resources.Black_Rookie_Classic

        BlackPawn1.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn2.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn3.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn4.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn5.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn6.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn7.InitialImage = My.Resources.Black_Pawn_Classic
        BlackPawn8.InitialImage = My.Resources.Black_Pawn_Classic
        BlackRook1.InitialImage = My.Resources.Black_Rook_Classic
        BlackRook2.InitialImage = My.Resources.Black_Rook_Classic
        BlackKnight1.InitialImage = My.Resources.Black_Knight_Classic
        BlackKnight2.InitialImage = My.Resources.Black_Knight_Classic
        BlackKnight3.InitialImage = My.Resources.Black_Knight_Classic
        BlackBishop1.InitialImage = My.Resources.Black_Bishop_Classic
        BlackBishop2.InitialImage = My.Resources.Black_Bishop_Classic
        BlackQueen1.InitialImage = My.Resources.Black_Queen_Classic
        BlackQueen2.InitialImage = My.Resources.Black_Queen_Classic
        BlackKing.InitialImage = My.Resources.Black_King_Classic
        BlackRookie1.InitialImage = My.Resources.Black_Rookie_Classic
        BlackRookie2.InitialImage = My.Resources.Black_Rookie_Classic

    End Sub

    Public Sub NeoWoodPieces()

        WhitePawn1.BackgroundImage = My.Resources.White_Pawn
        WhitePawn2.BackgroundImage = My.Resources.White_Pawn
        WhitePawn3.BackgroundImage = My.Resources.White_Pawn
        WhitePawn4.BackgroundImage = My.Resources.White_Pawn
        WhitePawn5.BackgroundImage = My.Resources.White_Pawn
        WhitePawn6.BackgroundImage = My.Resources.White_Pawn
        WhitePawn7.BackgroundImage = My.Resources.White_Pawn
        WhitePawn8.BackgroundImage = My.Resources.White_Pawn
        WhiteRook1.BackgroundImage = My.Resources.White_Rook
        WhiteRook2.BackgroundImage = My.Resources.White_Rook
        WhiteKnight1.BackgroundImage = My.Resources.White_Knight
        WhiteKnight2.BackgroundImage = My.Resources.White_Knight
        WhiteKnight3.BackgroundImage = My.Resources.White_Knight
        WhiteBishop1.BackgroundImage = My.Resources.White_Bishop
        WhiteBishop2.BackgroundImage = My.Resources.White_Bishop
        WhiteQueen1.BackgroundImage = My.Resources.White_Queen
        WhiteQueen2.BackgroundImage = My.Resources.White_Queen
        WhiteKing.BackgroundImage = My.Resources.White_King
        WhiteRookie1.BackgroundImage = My.Resources.White_Rookie
        WhiteRookie2.BackgroundImage = My.Resources.White_Rookie

        WhitePawn1.InitialImage = My.Resources.White_Pawn
        WhitePawn2.InitialImage = My.Resources.White_Pawn
        WhitePawn3.InitialImage = My.Resources.White_Pawn
        WhitePawn4.InitialImage = My.Resources.White_Pawn
        WhitePawn5.InitialImage = My.Resources.White_Pawn
        WhitePawn6.InitialImage = My.Resources.White_Pawn
        WhitePawn7.InitialImage = My.Resources.White_Pawn
        WhitePawn8.InitialImage = My.Resources.White_Pawn
        WhiteRook1.InitialImage = My.Resources.White_Rook
        WhiteRook2.InitialImage = My.Resources.White_Rook
        WhiteKnight1.InitialImage = My.Resources.White_Knight
        WhiteKnight2.InitialImage = My.Resources.White_Knight
        WhiteKnight3.InitialImage = My.Resources.White_Knight
        WhiteBishop1.InitialImage = My.Resources.White_Bishop
        WhiteBishop2.InitialImage = My.Resources.White_Bishop
        WhiteQueen1.InitialImage = My.Resources.White_Queen
        WhiteQueen2.InitialImage = My.Resources.White_Queen
        WhiteKing.InitialImage = My.Resources.White_King
        WhiteRookie1.InitialImage = My.Resources.White_Rookie
        WhiteRookie2.InitialImage = My.Resources.White_Rookie



        BlackPawn1.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn2.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn3.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn4.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn5.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn6.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn7.BackgroundImage = My.Resources.Black_Pawn
        BlackPawn8.BackgroundImage = My.Resources.Black_Pawn
        BlackRook1.BackgroundImage = My.Resources.Black_Rook
        BlackRook2.BackgroundImage = My.Resources.Black_Rook
        BlackKnight1.BackgroundImage = My.Resources.Black_Knight
        BlackKnight2.BackgroundImage = My.Resources.Black_Knight
        BlackKnight3.BackgroundImage = My.Resources.Black_Knight
        BlackBishop1.BackgroundImage = My.Resources.Black_Bishop
        BlackBishop2.BackgroundImage = My.Resources.Black_Bishop
        BlackQueen1.BackgroundImage = My.Resources.Black_Queen
        BlackQueen2.BackgroundImage = My.Resources.Black_Queen
        BlackKing.BackgroundImage = My.Resources.Black_King
        BlackRookie1.BackgroundImage = My.Resources.Black_Rookie
        BlackRookie2.BackgroundImage = My.Resources.Black_Rookie

        BlackPawn1.InitialImage = My.Resources.Black_Pawn
        BlackPawn2.InitialImage = My.Resources.Black_Pawn
        BlackPawn3.InitialImage = My.Resources.Black_Pawn
        BlackPawn4.InitialImage = My.Resources.Black_Pawn
        BlackPawn5.InitialImage = My.Resources.Black_Pawn
        BlackPawn6.InitialImage = My.Resources.Black_Pawn
        BlackPawn7.InitialImage = My.Resources.Black_Pawn
        BlackPawn8.InitialImage = My.Resources.Black_Pawn
        BlackRook1.InitialImage = My.Resources.Black_Rook
        BlackRook2.InitialImage = My.Resources.Black_Rook
        BlackKnight1.InitialImage = My.Resources.Black_Knight
        BlackKnight2.InitialImage = My.Resources.Black_Knight
        BlackKnight3.InitialImage = My.Resources.Black_Knight
        BlackBishop1.InitialImage = My.Resources.Black_Bishop
        BlackBishop2.InitialImage = My.Resources.Black_Bishop
        BlackQueen1.InitialImage = My.Resources.Black_Queen
        BlackQueen2.InitialImage = My.Resources.Black_Queen
        BlackKing.InitialImage = My.Resources.Black_King
        BlackRookie1.InitialImage = My.Resources.Black_Rookie
        BlackRookie2.InitialImage = My.Resources.Black_Rookie

    End Sub

    Public Sub NeoPieces()

        WhitePawn1.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn2.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn3.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn4.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn5.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn6.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn7.BackgroundImage = My.Resources.White_Pawn_Neo
        WhitePawn8.BackgroundImage = My.Resources.White_Pawn_Neo
        WhiteRook1.BackgroundImage = My.Resources.White_Rook_Neo
        WhiteRook2.BackgroundImage = My.Resources.White_Rook_Neo
        WhiteKnight1.BackgroundImage = My.Resources.White_Knight_Neo
        WhiteKnight2.BackgroundImage = My.Resources.White_Knight_Neo
        WhiteKnight3.BackgroundImage = My.Resources.White_Knight_Neo
        WhiteBishop1.BackgroundImage = My.Resources.White_Bishop_Neo
        WhiteBishop2.BackgroundImage = My.Resources.White_Bishop_Neo
        WhiteQueen1.BackgroundImage = My.Resources.White_Queen_Neo
        WhiteQueen2.BackgroundImage = My.Resources.White_Queen_Neo
        WhiteKing.BackgroundImage = My.Resources.White_King_Neo
        WhiteRookie1.BackgroundImage = My.Resources.White_Rookie_Neo
        WhiteRookie2.BackgroundImage = My.Resources.White_Rookie_Neo

        WhitePawn1.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn2.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn3.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn4.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn5.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn6.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn7.InitialImage = My.Resources.White_Pawn_Neo
        WhitePawn8.InitialImage = My.Resources.White_Pawn_Neo
        WhiteRook1.InitialImage = My.Resources.White_Rook_Neo
        WhiteRook2.InitialImage = My.Resources.White_Rook_Neo
        WhiteKnight1.InitialImage = My.Resources.White_Knight_Neo
        WhiteKnight2.InitialImage = My.Resources.White_Knight_Neo
        WhiteKnight3.InitialImage = My.Resources.White_Knight_Neo
        WhiteBishop1.InitialImage = My.Resources.White_Bishop_Neo
        WhiteBishop2.InitialImage = My.Resources.White_Bishop_Neo
        WhiteQueen1.InitialImage = My.Resources.White_Queen_Neo
        WhiteQueen2.InitialImage = My.Resources.White_Queen_Neo
        WhiteKing.InitialImage = My.Resources.White_King_Neo
        WhiteRookie1.InitialImage = My.Resources.White_Rookie_Neo
        WhiteRookie2.InitialImage = My.Resources.White_Rookie_Neo



        BlackPawn1.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn2.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn3.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn4.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn5.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn6.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn7.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackPawn8.BackgroundImage = My.Resources.Black_Pawn_Neo
        BlackRook1.BackgroundImage = My.Resources.Black_Rook_Neo
        BlackRook2.BackgroundImage = My.Resources.Black_Rook_Neo
        BlackKnight1.BackgroundImage = My.Resources.Black_Knight_Neo
        BlackKnight2.BackgroundImage = My.Resources.Black_Knight_Neo
        BlackKnight3.BackgroundImage = My.Resources.Black_Knight_Neo
        BlackBishop1.BackgroundImage = My.Resources.Black_Bishop_Neo
        BlackBishop2.BackgroundImage = My.Resources.Black_Bishop_Neo
        BlackQueen1.BackgroundImage = My.Resources.Black_Queen_Neo
        BlackQueen2.BackgroundImage = My.Resources.Black_Queen_Neo
        BlackKing.BackgroundImage = My.Resources.Black_King_Neo
        BlackRookie1.BackgroundImage = My.Resources.Black_Rookie_Neo
        BlackRookie2.BackgroundImage = My.Resources.Black_Rookie_Neo

        BlackPawn1.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn2.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn3.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn4.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn5.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn6.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn7.InitialImage = My.Resources.Black_Pawn_Neo
        BlackPawn8.InitialImage = My.Resources.Black_Pawn_Neo
        BlackRook1.InitialImage = My.Resources.Black_Rook_Neo
        BlackRook2.InitialImage = My.Resources.Black_Rook_Neo
        BlackKnight1.InitialImage = My.Resources.Black_Knight_Neo
        BlackKnight2.InitialImage = My.Resources.Black_Knight_Neo
        BlackKnight3.InitialImage = My.Resources.Black_Knight_Neo
        BlackBishop1.InitialImage = My.Resources.Black_Bishop_Neo
        BlackBishop2.InitialImage = My.Resources.Black_Bishop_Neo
        BlackQueen1.InitialImage = My.Resources.Black_Queen_Neo
        BlackQueen2.InitialImage = My.Resources.Black_Queen_Neo
        BlackKing.InitialImage = My.Resources.Black_King_Neo
        BlackRookie1.InitialImage = My.Resources.Black_Rookie_Neo
        BlackRookie2.InitialImage = My.Resources.Black_Rookie_Neo

    End Sub

    'Moving a Piece Subs

    Public Sub HideAllPossibleMoves()

        PossibleMove_11.Visible = False
        PossibleMove_12.Visible = False
        PossibleMove_13.Visible = False
        PossibleMove_14.Visible = False
        PossibleMove_15.Visible = False
        PossibleMove_16.Visible = False
        PossibleMove_17.Visible = False
        PossibleMove_18.Visible = False
        PossibleMove_21.Visible = False
        PossibleMove_22.Visible = False
        PossibleMove_23.Visible = False
        PossibleMove_24.Visible = False
        PossibleMove_25.Visible = False
        PossibleMove_26.Visible = False
        PossibleMove_27.Visible = False
        PossibleMove_28.Visible = False
        PossibleMove_31.Visible = False
        PossibleMove_32.Visible = False
        PossibleMove_33.Visible = False
        PossibleMove_34.Visible = False
        PossibleMove_35.Visible = False
        PossibleMove_36.Visible = False
        PossibleMove_37.Visible = False
        PossibleMove_38.Visible = False
        PossibleMove_41.Visible = False
        PossibleMove_42.Visible = False
        PossibleMove_43.Visible = False
        PossibleMove_44.Visible = False
        PossibleMove_45.Visible = False
        PossibleMove_46.Visible = False
        PossibleMove_47.Visible = False
        PossibleMove_48.Visible = False
        PossibleMove_51.Visible = False
        PossibleMove_52.Visible = False
        PossibleMove_53.Visible = False
        PossibleMove_54.Visible = False
        PossibleMove_55.Visible = False
        PossibleMove_56.Visible = False
        PossibleMove_57.Visible = False
        PossibleMove_58.Visible = False
        PossibleMove_61.Visible = False
        PossibleMove_62.Visible = False
        PossibleMove_63.Visible = False
        PossibleMove_64.Visible = False
        PossibleMove_65.Visible = False
        PossibleMove_66.Visible = False
        PossibleMove_67.Visible = False
        PossibleMove_68.Visible = False
        PossibleMove_71.Visible = False
        PossibleMove_72.Visible = False
        PossibleMove_73.Visible = False
        PossibleMove_74.Visible = False
        PossibleMove_75.Visible = False
        PossibleMove_76.Visible = False
        PossibleMove_77.Visible = False
        PossibleMove_78.Visible = False
        PossibleMove_81.Visible = False
        PossibleMove_82.Visible = False
        PossibleMove_83.Visible = False
        PossibleMove_84.Visible = False
        PossibleMove_85.Visible = False
        PossibleMove_86.Visible = False
        PossibleMove_87.Visible = False
        PossibleMove_88.Visible = False
        PossibleMove_91.Visible = False
        PossibleMove_92.Visible = False
        PossibleMove_93.Visible = False
        PossibleMove_94.Visible = False
        PossibleMove_95.Visible = False
        PossibleMove_96.Visible = False
        PossibleMove_97.Visible = False
        PossibleMove_98.Visible = False
        PossibleMove_101.Visible = False
        PossibleMove_102.Visible = False
        PossibleMove_103.Visible = False
        PossibleMove_104.Visible = False
        PossibleMove_105.Visible = False
        PossibleMove_106.Visible = False
        PossibleMove_107.Visible = False
        PossibleMove_108.Visible = False

        EnPassant1.Visible = False
        EnPassant2.Visible = False
        EnPassant3.Visible = False
        EnPassant4.Visible = False
        EnPassant5.Visible = False
        EnPassant6.Visible = False
        EnPassant7.Visible = False
        EnPassant8.Visible = False
        EnPassant9.Visible = False
        EnPassant10.Visible = False
        EnPassant11.Visible = False
        EnPassant12.Visible = False
        EnPassant13.Visible = False
        EnPassant14.Visible = False
        EnPassant15.Visible = False
        EnPassant16.Visible = False

    End Sub

    Public Sub ShowEnPassant(Number As Integer)

        Select Case Number

            Case 1

                EnPassant1.Visible = True

            Case 2

                EnPassant2.Visible = True

            Case 3

                EnPassant3.Visible = True

            Case 4

                EnPassant4.Visible = True

            Case 5

                EnPassant5.Visible = True

            Case 6

                EnPassant6.Visible = True

            Case 7

                EnPassant7.Visible = True

            Case 8

                EnPassant8.Visible = True

            Case 9

                EnPassant9.Visible = True

            Case 10

                EnPassant10.Visible = True

            Case 11

                EnPassant11.Visible = True

            Case 12

                EnPassant12.Visible = True

            Case 13

                EnPassant13.Visible = True

            Case 14

                EnPassant14.Visible = True

            Case 15

                EnPassant15.Visible = True

            Case 16

                EnPassant16.Visible = True

        End Select

    End Sub

    Public Sub ShowAllPossibleMoves(PossMove As Integer)

        If PossMove = 11 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_11.Visible = True

        ElseIf PossMove = 12 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_12.Visible = True

        ElseIf PossMove = 13 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_13.Visible = True

        ElseIf PossMove = 14 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_14.Visible = True

        ElseIf PossMove = 15 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_15.Visible = True

        ElseIf PossMove = 16 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_16.Visible = True

        ElseIf PossMove = 17 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_17.Visible = True

        ElseIf PossMove = 18 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_18.Visible = True

        ElseIf PossMove = 21 Then

            PossibleMove_21.Visible = True

        ElseIf PossMove = 22 Then

            PossibleMove_22.Visible = True

        ElseIf PossMove = 23 Then

            PossibleMove_23.Visible = True

        ElseIf PossMove = 24 Then

            PossibleMove_24.Visible = True

        ElseIf PossMove = 25 Then

            PossibleMove_25.Visible = True

        ElseIf PossMove = 26 Then

            PossibleMove_26.Visible = True

        ElseIf PossMove = 27 Then

            PossibleMove_27.Visible = True

        ElseIf PossMove = 28 Then

            PossibleMove_28.Visible = True

        ElseIf PossMove = 31 Then

            PossibleMove_31.Visible = True

        ElseIf PossMove = 32 Then

            PossibleMove_32.Visible = True

        ElseIf PossMove = 33 Then

            PossibleMove_33.Visible = True

        ElseIf PossMove = 34 Then

            PossibleMove_34.Visible = True

        ElseIf PossMove = 35 Then

            PossibleMove_35.Visible = True

        ElseIf PossMove = 36 Then

            PossibleMove_36.Visible = True

        ElseIf PossMove = 37 Then

            PossibleMove_37.Visible = True

        ElseIf PossMove = 38 Then

            PossibleMove_38.Visible = True

        ElseIf PossMove = 41 Then

            PossibleMove_41.Visible = True

        ElseIf PossMove = 42 Then

            PossibleMove_42.Visible = True

        ElseIf PossMove = 43 Then

            PossibleMove_43.Visible = True

        ElseIf PossMove = 44 Then

            PossibleMove_44.Visible = True

        ElseIf PossMove = 45 Then

            PossibleMove_45.Visible = True

        ElseIf PossMove = 46 Then

            PossibleMove_46.Visible = True

        ElseIf PossMove = 47 Then

            PossibleMove_47.Visible = True

        ElseIf PossMove = 48 Then

            PossibleMove_48.Visible = True

        ElseIf PossMove = 51 Then

            PossibleMove_51.Visible = True

        ElseIf PossMove = 52 Then

            PossibleMove_52.Visible = True

        ElseIf PossMove = 53 Then

            PossibleMove_53.Visible = True

        ElseIf PossMove = 54 Then

            PossibleMove_54.Visible = True

        ElseIf PossMove = 55 Then

            PossibleMove_55.Visible = True

        ElseIf PossMove = 56 Then

            PossibleMove_56.Visible = True

        ElseIf PossMove = 57 Then

            PossibleMove_57.Visible = True

        ElseIf PossMove = 58 Then

            PossibleMove_58.Visible = True

        ElseIf PossMove = 61 Then

            PossibleMove_61.Visible = True

        ElseIf PossMove = 62 Then

            PossibleMove_62.Visible = True

        ElseIf PossMove = 63 Then

            PossibleMove_63.Visible = True

        ElseIf PossMove = 64 Then

            PossibleMove_64.Visible = True

        ElseIf PossMove = 65 Then

            PossibleMove_65.Visible = True

        ElseIf PossMove = 66 Then

            PossibleMove_66.Visible = True

        ElseIf PossMove = 67 Then

            PossibleMove_67.Visible = True

        ElseIf PossMove = 68 Then

            PossibleMove_68.Visible = True

        ElseIf PossMove = 71 Then

            PossibleMove_71.Visible = True

        ElseIf PossMove = 72 Then

            PossibleMove_72.Visible = True

        ElseIf PossMove = 73 Then

            PossibleMove_73.Visible = True

        ElseIf PossMove = 74 Then

            PossibleMove_74.Visible = True

        ElseIf PossMove = 75 Then

            PossibleMove_75.Visible = True

        ElseIf PossMove = 76 Then

            PossibleMove_76.Visible = True

        ElseIf PossMove = 77 Then

            PossibleMove_77.Visible = True

        ElseIf PossMove = 78 Then

            PossibleMove_78.Visible = True

        ElseIf PossMove = 81 Then

            PossibleMove_81.Visible = True

        ElseIf PossMove = 82 Then

            PossibleMove_82.Visible = True

        ElseIf PossMove = 83 Then

            PossibleMove_83.Visible = True

        ElseIf PossMove = 84 Then

            PossibleMove_84.Visible = True

        ElseIf PossMove = 85 Then

            PossibleMove_85.Visible = True

        ElseIf PossMove = 86 Then

            PossibleMove_86.Visible = True

        ElseIf PossMove = 87 Then

            PossibleMove_87.Visible = True

        ElseIf PossMove = 88 Then

            PossibleMove_88.Visible = True

        ElseIf PossMove = 91 Then

            PossibleMove_91.Visible = True

        ElseIf PossMove = 92 Then

            PossibleMove_92.Visible = True

        ElseIf PossMove = 93 Then

            PossibleMove_93.Visible = True

        ElseIf PossMove = 94 Then

            PossibleMove_94.Visible = True

        ElseIf PossMove = 95 Then

            PossibleMove_95.Visible = True

        ElseIf PossMove = 96 Then

            PossibleMove_96.Visible = True

        ElseIf PossMove = 97 Then

            PossibleMove_97.Visible = True

        ElseIf PossMove = 98 Then

            PossibleMove_98.Visible = True

        ElseIf PossMove = 101 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_101.Visible = True

        ElseIf PossMove = 102 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_102.Visible = True

        ElseIf PossMove = 103 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_103.Visible = True

        ElseIf PossMove = 104 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_104.Visible = True

        ElseIf PossMove = 105 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_105.Visible = True

        ElseIf PossMove = 106 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_106.Visible = True

        ElseIf PossMove = 107 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_107.Visible = True

        ElseIf PossMove = 108 And Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

            PossibleMove_108.Visible = True

        End If

    End Sub

    Public Function PieceToMove(Piece As Integer)

        If Piece = 11 Then

            Return WhitePawn1

        ElseIf Piece = 12 Then

            Return WhitePawn2

        ElseIf Piece = 13 Then

            Return WhitePawn3

        ElseIf Piece = 14 Then

            Return WhitePawn4

        ElseIf Piece = 15 Then

            Return WhitePawn5

        ElseIf Piece = 16 Then

            Return WhitePawn6

        ElseIf Piece = 17 Then

            Return WhitePawn7

        ElseIf Piece = 18 Then

            Return WhitePawn8

        ElseIf Piece = 21 Then

            Return WhiteRook1

        ElseIf Piece = 22 Then

            Return WhiteRook2

        ElseIf Piece = 31 Then

            Return WhiteKnight1

        ElseIf Piece = 32 Then

            Return WhiteKnight2

        ElseIf Piece = 33 Then

            Return WhiteKnight3

        ElseIf Piece = 41 Then

            Return WhiteBishop1

        ElseIf Piece = 42 Then

            Return WhiteBishop2

        ElseIf Piece = 51 Then

            Return WhiteQueen1

        ElseIf Piece = 52 Then

            Return WhiteQueen2

        ElseIf Piece = 60 Then

            Return WhiteKing

        ElseIf Piece = 71 Then

            Return WhiteRookie1

        ElseIf Piece = 72 Then

            Return WhiteRookie2

        ElseIf Piece = -11 Then

            Return BlackPawn1

        ElseIf Piece = -12 Then

            Return BlackPawn2

        ElseIf Piece = -13 Then

            Return BlackPawn3

        ElseIf Piece = -14 Then

            Return BlackPawn4

        ElseIf Piece = -15 Then

            Return BlackPawn5

        ElseIf Piece = -16 Then

            Return BlackPawn6

        ElseIf Piece = -17 Then

            Return BlackPawn7

        ElseIf Piece = -18 Then

            Return BlackPawn8

        ElseIf Piece = -21 Then

            Return BlackRook1

        ElseIf Piece = -22 Then

            Return BlackRook2

        ElseIf Piece = -31 Then

            Return BlackKnight1

        ElseIf Piece = -32 Then

            Return BlackKnight2

        ElseIf Piece = -33 Then

            Return BlackKnight3

        ElseIf Piece = -41 Then

            Return BlackBishop1

        ElseIf Piece = -42 Then

            Return BlackBishop2

        ElseIf Piece = -51 Then

            Return BlackQueen1

        ElseIf Piece = -52 Then

            Return BlackQueen2

        ElseIf Piece = -60 Then

            Return BlackKing

        ElseIf Piece = -71 Then

            Return BlackRookie1

        ElseIf Piece = -72 Then

            Return BlackRookie2

        End If

    End Function

    Public Sub ThreatenedPieces(ThreatenedPiece As Integer)

        If ThreatenedPiece = 11 Then

            WhitePawn1.Cursor = Cursors.Hand

            WhitePawn1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 12 Then

            WhitePawn2.Cursor = Cursors.Hand

            WhitePawn2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 13 Then

            WhitePawn3.Cursor = Cursors.Hand

            WhitePawn3.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 14 Then

            WhitePawn4.Cursor = Cursors.Hand

            WhitePawn4.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 15 Then

            WhitePawn5.Cursor = Cursors.Hand

            WhitePawn5.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 16 Then

            WhitePawn6.Cursor = Cursors.Hand

            WhitePawn6.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 17 Then

            WhitePawn7.Cursor = Cursors.Hand

            WhitePawn7.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 18 Then

            WhitePawn8.Cursor = Cursors.Hand

            WhitePawn8.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 21 Then

            WhiteRook1.Cursor = Cursors.Hand

            WhiteRook1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 22 Then

            WhiteRook2.Cursor = Cursors.Hand

            WhiteRook2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 31 And TakeWhiteKnight1Elig(Abs(SelectedPiece)) = True Then

            WhiteKnight1.Cursor = Cursors.Hand

            WhiteKnight1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 32 And TakeWhiteKnight2Elig(Abs(SelectedPiece)) = True Then

            WhiteKnight2.Cursor = Cursors.Hand

            WhiteKnight2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 33 And TakeWhiteKnight3Elig(Abs(SelectedPiece)) = True Then

            WhiteKnight3.Cursor = Cursors.Hand

            WhiteKnight3.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 41 Then

            WhiteBishop1.Cursor = Cursors.Hand

            WhiteBishop1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 42 Then

            WhiteBishop2.Cursor = Cursors.Hand

            WhiteBishop2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 51 Then

            If Ceiling(SelectedPiece / 10) = -4 Then

                ParalysedWhiteQueen(1) = True

            End If

            WhiteQueen1.Cursor = Cursors.Hand

            WhiteQueen1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 52 Then

            If Ceiling(SelectedPiece / 10) = -4 Then

                ParalysedWhiteQueen(2) = True

            End If

            WhiteQueen2.Cursor = Cursors.Hand

            WhiteQueen2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 60 Then

            WhiteKing.Cursor = Cursors.Hand

            WhiteKing.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 71 Then

            WhiteRookie1.Cursor = Cursors.Hand

            WhiteRookie1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = 72 Then

            WhiteRookie2.Cursor = Cursors.Hand

            WhiteRookie2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -11 Then

            BlackPawn1.Cursor = Cursors.Hand

            BlackPawn1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -12 Then

            BlackPawn2.Cursor = Cursors.Hand

            BlackPawn2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -13 Then

            BlackPawn3.Cursor = Cursors.Hand

            BlackPawn3.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -14 Then

            BlackPawn4.Cursor = Cursors.Hand

            BlackPawn4.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -15 Then

            BlackPawn5.Cursor = Cursors.Hand

            BlackPawn5.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -16 Then

            BlackPawn6.Cursor = Cursors.Hand

            BlackPawn6.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -17 Then

            BlackPawn7.Cursor = Cursors.Hand

            BlackPawn7.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -18 Then

            BlackPawn8.Cursor = Cursors.Hand

            BlackPawn8.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -21 Then

            BlackRook1.Cursor = Cursors.Hand

            BlackRook1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -22 Then

            BlackRook2.Cursor = Cursors.Hand

            BlackRook2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -31 And TakeBlackKnight1Elig(Abs(SelectedPiece)) = True Then

            BlackKnight1.Cursor = Cursors.Hand

            BlackKnight1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -32 And TakeBlackKnight2Elig(Abs(SelectedPiece)) = True Then

            BlackKnight2.Cursor = Cursors.Hand

            BlackKnight2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -33 And TakeBlackKnight3Elig(Abs(SelectedPiece)) = True Then

            BlackKnight3.Cursor = Cursors.Hand

            BlackKnight3.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -41 Then

            BlackBishop1.Cursor = Cursors.Hand

            BlackBishop1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -42 Then

            BlackBishop2.Cursor = Cursors.Hand

            BlackBishop2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -51 Then

            If Floor(SelectedPiece / 10) = 4 Then

                ParalysedBlackQueen(1) = True

            End If

            BlackQueen1.Cursor = Cursors.Hand

            BlackQueen1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -52 Then

            If Floor(SelectedPiece / 10) = 4 Then

                ParalysedBlackQueen(2) = True

            End If

            BlackQueen2.Cursor = Cursors.Hand

            BlackQueen2.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -60 Then

            BlackKing.Cursor = Cursors.Hand

            BlackKing.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -71 Then

            BlackRookie1.Cursor = Cursors.Hand

            BlackRookie1.Image = My.Resources.Take

        ElseIf ThreatenedPiece = -72 Then

            BlackRookie2.Cursor = Cursors.Hand

            BlackRookie2.Image = My.Resources.Take

        End If

    End Sub

    'Cursors and Image

    Public Sub DefaultCursorForBlack()

        BlackPawn1.Cursor = Cursors.Default
        BlackPawn2.Cursor = Cursors.Default
        BlackPawn3.Cursor = Cursors.Default
        BlackPawn4.Cursor = Cursors.Default
        BlackPawn5.Cursor = Cursors.Default
        BlackPawn6.Cursor = Cursors.Default
        BlackPawn7.Cursor = Cursors.Default
        BlackPawn8.Cursor = Cursors.Default
        BlackRook1.Cursor = Cursors.Default
        BlackRook2.Cursor = Cursors.Default
        BlackKnight1.Cursor = Cursors.Default
        BlackKnight2.Cursor = Cursors.Default
        BlackKnight3.Cursor = Cursors.Default
        BlackBishop1.Cursor = Cursors.Default
        BlackBishop2.Cursor = Cursors.Default
        BlackKing.Cursor = Cursors.Default
        BlackQueen1.Cursor = Cursors.Default
        BlackQueen2.Cursor = Cursors.Default
        BlackRookie1.Cursor = Cursors.Default
        BlackRookie2.Cursor = Cursors.Default

    End Sub

    Public Sub DefaultCursorForWhite()

        WhitePawn1.Cursor = Cursors.Default
        WhitePawn2.Cursor = Cursors.Default
        WhitePawn3.Cursor = Cursors.Default
        WhitePawn4.Cursor = Cursors.Default
        WhitePawn5.Cursor = Cursors.Default
        WhitePawn6.Cursor = Cursors.Default
        WhitePawn7.Cursor = Cursors.Default
        WhitePawn8.Cursor = Cursors.Default
        WhiteRook1.Cursor = Cursors.Default
        WhiteRook2.Cursor = Cursors.Default
        WhiteKnight1.Cursor = Cursors.Default
        WhiteKnight2.Cursor = Cursors.Default
        WhiteKnight3.Cursor = Cursors.Default
        WhiteBishop1.Cursor = Cursors.Default
        WhiteBishop2.Cursor = Cursors.Default
        WhiteKing.Cursor = Cursors.Default
        WhiteQueen1.Cursor = Cursors.Default
        WhiteQueen2.Cursor = Cursors.Default
        WhiteRookie1.Cursor = Cursors.Default
        WhiteRookie2.Cursor = Cursors.Default

    End Sub

    Public Sub HandCursorForBlack()

        If BlackPawn1.Size.Height = 100 Then

            BlackPawn1.Cursor = Cursors.Hand

        End If

        If BlackPawn2.Size.Height = 100 Then

            BlackPawn2.Cursor = Cursors.Hand

        End If

        If BlackPawn3.Size.Height = 100 Then

            BlackPawn3.Cursor = Cursors.Hand

        End If

        If BlackPawn4.Size.Height = 100 Then

            BlackPawn4.Cursor = Cursors.Hand

        End If

        If BlackPawn5.Size.Height = 100 Then

            BlackPawn5.Cursor = Cursors.Hand

        End If

        If BlackPawn6.Size.Height = 100 Then

            BlackPawn6.Cursor = Cursors.Hand

        End If

        If BlackPawn7.Size.Height = 100 Then

            BlackPawn7.Cursor = Cursors.Hand

        End If

        If BlackPawn8.Size.Height = 100 Then

            BlackPawn8.Cursor = Cursors.Hand

        End If

        If BlackRook1.Size.Height = 100 Then

            BlackRook1.Cursor = Cursors.Hand

        End If

        If BlackRook2.Size.Height = 100 Then

            BlackRook2.Cursor = Cursors.Hand

        End If

        If BlackKnight1.Size.Height = 100 Then

            BlackKnight1.Cursor = Cursors.Hand

        End If

        If BlackKnight2.Size.Height = 100 Then

            BlackKnight2.Cursor = Cursors.Hand

        End If

        If BlackKnight3.Size.Height = 100 Then

            BlackKnight3.Cursor = Cursors.Hand

        End If

        If BlackBishop1.Size.Height = 100 Then

            BlackBishop1.Cursor = Cursors.Hand

        End If

        If BlackBishop2.Size.Height = 100 Then

            BlackBishop2.Cursor = Cursors.Hand

        End If

        If BlackQueen1.Size.Height = 100 Then

            BlackQueen1.Cursor = Cursors.Hand

        End If

        If BlackQueen2.Size.Height = 100 Then

            BlackQueen2.Cursor = Cursors.Hand

        End If

        If BlackKing.Size.Height = 100 Then

            BlackKing.Cursor = Cursors.Hand

        End If

        If BlackRookie1.Size.Height = 100 Then

            BlackRookie1.Cursor = Cursors.Hand

        End If

        If BlackRookie2.Size.Height = 100 Then

            BlackRookie2.Cursor = Cursors.Hand

        End If

    End Sub

    Public Sub HandCursorForWhite()

        If WhitePawn1.Size.Height = 100 Then

            WhitePawn1.Cursor = Cursors.Hand

        End If

        If WhitePawn2.Size.Height = 100 Then

            WhitePawn2.Cursor = Cursors.Hand

        End If

        If WhitePawn3.Size.Height = 100 Then

            WhitePawn3.Cursor = Cursors.Hand

        End If

        If WhitePawn4.Size.Height = 100 Then

            WhitePawn4.Cursor = Cursors.Hand

        End If

        If WhitePawn5.Size.Height = 100 Then

            WhitePawn5.Cursor = Cursors.Hand

        End If

        If WhitePawn6.Size.Height = 100 Then

            WhitePawn6.Cursor = Cursors.Hand

        End If

        If WhitePawn7.Size.Height = 100 Then

            WhitePawn7.Cursor = Cursors.Hand

        End If

        If WhitePawn8.Size.Height = 100 Then

            WhitePawn8.Cursor = Cursors.Hand

        End If

        If WhiteRook1.Size.Height = 100 Then

            WhiteRook1.Cursor = Cursors.Hand

        End If

        If WhiteRook2.Size.Height = 100 Then

            WhiteRook2.Cursor = Cursors.Hand

        End If

        If WhiteKnight1.Size.Height = 100 Then

            WhiteKnight1.Cursor = Cursors.Hand

        End If

        If WhiteKnight2.Size.Height = 100 Then

            WhiteKnight2.Cursor = Cursors.Hand

        End If

        If WhiteKnight3.Size.Height = 100 Then

            WhiteKnight3.Cursor = Cursors.Hand

        End If

        If WhiteBishop1.Size.Height = 100 Then

            WhiteBishop1.Cursor = Cursors.Hand

        End If

        If WhiteBishop2.Size.Height = 100 Then

            WhiteBishop2.Cursor = Cursors.Hand

        End If

        If WhiteQueen1.Size.Height = 100 Then

            WhiteQueen1.Cursor = Cursors.Hand

        End If

        If WhiteQueen2.Size.Height = 100 Then

            WhiteQueen2.Cursor = Cursors.Hand

        End If

        If WhiteKing.Size.Height = 100 Then

            WhiteKing.Cursor = Cursors.Hand

        End If

        If WhiteRookie1.Size.Height = 100 Then

            WhiteRookie1.Cursor = Cursors.Hand

        End If

        If WhiteRookie2.Size.Height = 100 Then

            WhiteRookie2.Cursor = Cursors.Hand

        End If

    End Sub

    Public Sub InitialImageForBlack()

        BlackPawn1.Image = Nothing
        BlackPawn2.Image = Nothing
        BlackPawn3.Image = Nothing
        BlackPawn4.Image = Nothing
        BlackPawn5.Image = Nothing
        BlackPawn6.Image = Nothing
        BlackPawn7.Image = Nothing
        BlackPawn8.Image = Nothing
        BlackRook1.Image = Nothing
        BlackRook2.Image = Nothing
        BlackKnight1.Image = Nothing
        BlackKnight2.Image = Nothing
        BlackKnight3.Image = Nothing
        BlackBishop1.Image = Nothing
        BlackBishop2.Image = Nothing
        BlackQueen1.Image = Nothing
        BlackQueen2.Image = Nothing
        BlackKing.Image = Nothing
        BlackRookie1.Image = Nothing
        BlackRookie2.Image = Nothing

        BlackPawn1.BackgroundImage = BlackPawn1.InitialImage
        BlackPawn2.BackgroundImage = BlackPawn2.InitialImage
        BlackPawn3.BackgroundImage = BlackPawn3.InitialImage
        BlackPawn4.BackgroundImage = BlackPawn4.InitialImage
        BlackPawn5.BackgroundImage = BlackPawn5.InitialImage
        BlackPawn6.BackgroundImage = BlackPawn6.InitialImage
        BlackPawn7.BackgroundImage = BlackPawn7.InitialImage
        BlackPawn8.BackgroundImage = BlackPawn8.InitialImage
        BlackRook1.BackgroundImage = BlackRook1.InitialImage
        BlackRook2.BackgroundImage = BlackRook2.InitialImage
        BlackKnight1.BackgroundImage = BlackKnight1.InitialImage
        BlackKnight2.BackgroundImage = BlackKnight2.InitialImage
        BlackKnight3.BackgroundImage = BlackKnight3.InitialImage
        BlackBishop1.BackgroundImage = BlackBishop1.InitialImage
        BlackBishop2.BackgroundImage = BlackBishop2.InitialImage
        BlackQueen1.BackgroundImage = BlackQueen1.InitialImage
        BlackQueen2.BackgroundImage = BlackQueen2.InitialImage
        BlackKing.BackgroundImage = BlackKing.InitialImage
        BlackRookie1.BackgroundImage = BlackRookie1.InitialImage
        BlackRookie2.BackgroundImage = BlackRookie2.InitialImage

    End Sub

    Public Sub InitialImageForWhite()

        WhitePawn1.Image = Nothing
        WhitePawn2.Image = Nothing
        WhitePawn3.Image = Nothing
        WhitePawn4.Image = Nothing
        WhitePawn5.Image = Nothing
        WhitePawn6.Image = Nothing
        WhitePawn7.Image = Nothing
        WhitePawn8.Image = Nothing
        WhiteRook1.Image = Nothing
        WhiteRook2.Image = Nothing
        WhiteKnight1.Image = Nothing
        WhiteKnight2.Image = Nothing
        WhiteKnight3.Image = Nothing
        WhiteBishop1.Image = Nothing
        WhiteBishop2.Image = Nothing
        WhiteQueen1.Image = Nothing
        WhiteQueen2.Image = Nothing
        WhiteKing.Image = Nothing
        WhiteRookie1.Image = Nothing
        WhiteRookie2.Image = Nothing

        WhitePawn1.BackgroundImage = WhitePawn1.InitialImage
        WhitePawn2.BackgroundImage = WhitePawn2.InitialImage
        WhitePawn3.BackgroundImage = WhitePawn3.InitialImage
        WhitePawn4.BackgroundImage = WhitePawn4.InitialImage
        WhitePawn5.BackgroundImage = WhitePawn5.InitialImage
        WhitePawn6.BackgroundImage = WhitePawn6.InitialImage
        WhitePawn7.BackgroundImage = WhitePawn7.InitialImage
        WhitePawn8.BackgroundImage = WhitePawn8.InitialImage
        WhiteRook1.BackgroundImage = WhiteRook1.InitialImage
        WhiteRook2.BackgroundImage = WhiteRook2.InitialImage
        WhiteKnight1.BackgroundImage = WhiteKnight1.InitialImage
        WhiteKnight2.BackgroundImage = WhiteKnight2.InitialImage
        WhiteKnight3.BackgroundImage = WhiteKnight3.InitialImage
        WhiteBishop1.BackgroundImage = WhiteBishop1.InitialImage
        WhiteBishop2.BackgroundImage = WhiteBishop2.InitialImage
        WhiteQueen1.BackgroundImage = WhiteQueen1.InitialImage
        WhiteQueen2.BackgroundImage = WhiteQueen2.InitialImage
        WhiteKing.BackgroundImage = WhiteKing.InitialImage
        WhiteRookie1.BackgroundImage = WhiteRookie1.InitialImage
        WhiteRookie2.BackgroundImage = WhiteRookie2.InitialImage

    End Sub

    'Knight's Hood

    Public Sub KnightsHoodOff()

        Select Case Form2.PiecesStyleCB.SelectedItem

            Case "Neo-Wood"

                If Floor(SelectedPiece / 10) = 3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.White_Knight
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.White_Knight

                ElseIf Ceiling(SelectedPiece / 10) = -3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.Black_Knight
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.Black_Knight

                End If

            Case "Classic"

                If Floor(SelectedPiece / 10) = 3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.White_Knight_Classic
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.White_Knight_Classic

                ElseIf Ceiling(SelectedPiece / 10) = -3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.Black_Knight_Classic
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.Black_Knight_Classic

                End If

            Case "Neo"

                If Floor(SelectedPiece / 10) = 3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.White_Knight_Neo
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.White_Knight_Neo

                ElseIf Ceiling(SelectedPiece / 10) = -3 Then

                    PieceToMove(SelectedPiece).InitialImage = My.Resources.Black_Knight_Neo
                    PieceToMove(SelectedPiece).BackgroundImage = My.Resources.Black_Knight_Neo

                End If

        End Select

    End Sub

    Public Sub KnightsHoodOn(Piece As Integer)

        Select Case Form2.PiecesStyleCB.SelectedItem

            Case "Neo-Wood"

                If Floor(Piece / 10) = 3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_White_Knight
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_White_Knight

                ElseIf Ceiling(Piece / 10) = -3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_Black_Knight
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_Black_Knight

                End If

            Case "Classic"

                If Floor(Piece / 10) = 3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_White_Knight_Classic
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_White_Knight_Classic

                ElseIf Ceiling(Piece / 10) = -3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_Black_Knight_Classic
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_Black_Knight_Classic

                End If

            Case "Neo"

                If Floor(Piece / 10) = 3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_White_Knight_Neo
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_White_Knight_Neo

                ElseIf Ceiling(Piece / 10) = -3 Then

                    PieceToMove(Piece).InitialImage = My.Resources.Hooded_Black_Knight_Neo
                    PieceToMove(Piece).BackgroundImage = My.Resources.Hooded_Black_Knight_Neo

                End If

        End Select

    End Sub

    'En Passant

    Public Sub ResetWhiteEnPassant()

        For counter = 1 To 8

            EnPassantWhitePawn(counter) = False

        Next

    End Sub

    Public Sub ResetBlackEnPassant()

        For counter = 1 To 8

            EnPassantBlackPawn(counter) = False

        Next

    End Sub

    Public Sub EnPassantWhite(counter1 As Integer, counter2 As Integer)

        If Floor(SelectedPiece / 10) = 1 And counter1 = 7 Then

            If Ceiling(Board(5, counter2 + 1) / 10) = -1 Then

                EnPassantWhitePawn(SelectedPiece - 10) = True

            End If

            If Ceiling(Board(5, counter2 - 1) / 10) = -1 Then

                EnPassantWhitePawn(SelectedPiece - 10) = True

            End If

        End If

    End Sub

    Public Sub EnPassantWhitePositions(counter1 As Integer, counter2 As Integer)

        If Floor(Board(counter1, counter2 + 1) / 10) = 1 Then

            If EnPassantWhitePawn(Board(counter1, counter2 + 1) - 10) = True Then

                Call ShowEnPassant(counter2 + 1 + 7)

            End If

        End If

        If Floor(Board(counter1, counter2 - 1) / 10) = 1 Then

            If EnPassantWhitePawn(Board(counter1, counter2 - 1) - 10) = True Then

                Call ShowEnPassant(counter2 - 1 + 7)

            End If

        End If

    End Sub

    Public Sub EnPassantBlack(counter1 As Integer, counter2 As Integer)

        If Ceiling(SelectedPiece / 10) = -1 And counter1 = 2 Then

            If Floor(Board(4, counter2 + 1) / 10) = 1 Then

                EnPassantBlackPawn(Abs(SelectedPiece) - 10) = True

            End If

            If Floor(Board(4, counter2 - 1) / 10) = 1 Then

                EnPassantBlackPawn(Abs(SelectedPiece) - 10) = True

            End If

        End If

    End Sub

    Public Sub EnPassantBlackPositions(counter1 As Integer, counter2 As Integer)

        If Ceiling(Board(counter1, counter2 + 1) / 10) = -1 Then

            If EnPassantBlackPawn(Abs(Board(counter1, counter2 + 1)) - 10) = True Then

                Call ShowEnPassant(counter2 + 1 - 1)

            End If

        End If

        If Ceiling(Board(counter1, counter2 - 1) / 10) = -1 Then

            If EnPassantBlackPawn(Abs(Board(counter1, counter2 - 1)) - 10) = True Then

                Call ShowEnPassant(counter2 - 1 - 1)

            End If

        End If

    End Sub

    'Take Knight Eligibility

    Public Sub ResetTakeWhiteKnightElig()

        For counter = 1 To 72

            TakeWhiteKnight1Elig(counter) = True
            TakeWhiteKnight2Elig(counter) = True
            TakeWhiteKnight3Elig(counter) = True

        Next

    End Sub

    Public Sub ResetTakeBlackKnightElig()

        For counter = 1 To 72

            TakeBlackKnight1Elig(counter) = True
            TakeBlackKnight2Elig(counter) = True
            TakeBlackKnight3Elig(counter) = True

        Next

    End Sub

    'Possible Move Procedure 1

    Public Sub PossibleMoveProcedure1()

        If Floor(Abs(SelectedPiece / 10)) = 1 Then

            SeventyFiveMoveRule = 75

        End If

        Select Case SelectedPiece

            Case 21

                LongCastleWhite = False

            Case 22

                ShortCastleWhite = False

            Case -21

                LongCastleBlack = False

            Case -22

                ShortCastleBlack = False

            Case 60

                ShortCastleWhite = False
                LongCastleWhite = False

            Case -60

                ShortCastleBlack = False
                LongCastleBlack = False

        End Select

        Call HideAllPossibleMoves()
        Call InitialImageForBlack()
        Call InitialImageForWhite()

        If WhiteTurn = True Then

            Call BlackTurnSub()
            Call DefaultCursorForWhite()
            Call ResetTakeBlackKnightElig()
            Call HandCursorForBlack()

        Else

            Call WhiteTurnSub()
            Call DefaultCursorForBlack()
            Call ResetTakeWhiteKnightElig()
            Call HandCursorForWhite()

        End If

    End Sub

    'Revivng the Queen

    Public Sub ReviveWhiteQueen(counter1 As Integer, counter2 As Integer)

        PromotionSound.Play()

        If WhiteQueen1.Size.Height = 31 Then

            LastTakenPieceWhite.Location = WhiteQueen1.Location

            Board(counter1, counter2) = 51

            WhiteQueen1Alive = True

            WhiteQueen1.Location = New Point(TempLocation)

            WhiteQueen1.Size = New Size(100, 100)

            WhiteQueen1.Cursor = Cursors.Hand

            WhiteQueen1.Visible = True

        ElseIf WhiteQueen2.Size.Height = 31 Then

            LastTakenPieceWhite.Location = WhiteQueen2.Location

            Board(counter1, counter2) = 52

            WhiteQueen2.Location = New Point(TempLocation)

            WhiteQueen2.Size = New Size(100, 100)

            WhitePiecesTaken -= 1

            WhiteQueen2.Cursor = Cursors.Hand

        ElseIf WhiteQueen2.Size.Height = 50 Then

            Board(counter1, counter2) = 52

            WhiteQueen2.Location = New Point(TempLocation)

            WhiteQueen2.Size = New Size(100, 100)

            WhiteQueen2.Visible = True

            WhiteQueen2.Cursor = Cursors.Hand

        End If

    End Sub

    Public Sub ReviveBlackQueen(counter1 As Integer, counter2 As Integer)

        PromotionSound.Play()

        If BlackQueen1.Size.Height = 31 Then

            LastTakenPieceBlack.Location = BlackQueen1.Location

            Board(counter1, counter2) = -51

            BlackQueen1Alive = True

            BlackQueen1.Location = New Point(TempLocation)

            BlackQueen1.Size = New Size(100, 100)

            BlackQueen1.Visible = True

        ElseIf BlackQueen2.Size.Height = 31 Then

            LastTakenPieceBlack.Location = BlackQueen2.Location

            Board(counter1, counter2) = -52

            BlackQueen2.Location = New Point(TempLocation)

            BlackQueen2.Size = New Size(100, 100)

            BlackQueen2.Cursor = Cursors.Hand

        ElseIf BlackQueen2.Size.Height = 50 Then

            Board(counter1, counter2) = -52

            BlackQueen2.Location = New Point(TempLocation)

            BlackQueen2.Size = New Size(100, 100)

            BlackQueen2.Visible = True

            BlackQueen2.Cursor = Cursors.Hand

        End If

    End Sub

    'Fusion

    Public Sub WhiteFusion(counter1 As Integer, counter2 As Integer)

        PromotionSound.Play()

        NumberOfWhitePawns -= 3

        If WhiteRookie1.Size.Height = 50 Then

            WhiteRookie1.Size = New Size(100, 100)
            WhiteRookie1.Location = New Point(TempLocation)
            WhiteRookie1.Visible = True

            PieceToMove(Board(counter1, counter2)).Visible = False
            PieceToMove(Board(counter1 + 1, counter2)).Visible = False
            PieceToMove(Board(counter1 - 1, counter2)).Visible = False

            Board(counter1, counter2) = 71
            Board(counter1 + 1, counter2) = 0
            Board(counter1 - 1, counter2) = 0

            If WhiteTurn = True Then

                WhiteRookie1.Cursor = Cursors.Hand

            End If

        ElseIf WhiteRookie2.Size.Height = 50 Then

            WhiteRookie2.Size = New Size(100, 100)
            WhiteRookie2.Location = New Point(TempLocation)
            WhiteRookie2.Visible = True

            PieceToMove(Board(counter1, counter2)).Visible = False
            PieceToMove(Board(counter1 + 1, counter2)).Visible = False
            PieceToMove(Board(counter1 - 1, counter2)).Visible = False

            Board(counter1, counter2) = 72
            Board(counter1 + 1, counter2) = 0
            Board(counter1 - 1, counter2) = 0

            If WhiteTurn = True Then

                WhiteRookie2.Cursor = Cursors.Hand

            End If

        End If

    End Sub

    Public Sub BlackFusion(counter1 As Integer, counter2 As Integer)

        PromotionSound.Play()

        NumberOfBlackPawns -= 3

        If BlackRookie1.Size.Height = 50 Then

            BlackRookie1.Size = New Size(100, 100)
            BlackRookie1.Location = New Point(TempLocation)
            BlackRookie1.Visible = True

            PieceToMove(Board(counter1, counter2)).Visible = False
            PieceToMove(Board(counter1 + 1, counter2)).Visible = False
            PieceToMove(Board(counter1 - 1, counter2)).Visible = False

            Board(counter1, counter2) = -71
            Board(counter1 + 1, counter2) = 0
            Board(counter1 - 1, counter2) = 0

            If WhiteTurn = False Then

                BlackRookie1.Cursor = Cursors.Hand

            End If

        ElseIf BlackRookie2.Size.Height = 50 Then

            BlackRookie2.Size = New Size(100, 100)
            BlackRookie2.Location = New Point(TempLocation)
            BlackRookie2.Visible = True

            PieceToMove(Board(counter1, counter2)).Visible = False
            PieceToMove(Board(counter1 + 1, counter2)).Visible = False
            PieceToMove(Board(counter1 - 1, counter2)).Visible = False

            Board(counter1, counter2) = -72
            Board(counter1 + 1, counter2) = 0
            Board(counter1 - 1, counter2) = 0

            If WhiteTurn = False Then

                BlackRookie2.Cursor = Cursors.Hand

            End If

        End If

    End Sub

    'Main Entrance

    Public Sub MainEntranceMidClmns(x As Boolean, Num1 As Integer, Num2 As Integer)

        Call KnightsHoodOff()

        If Num1 > 1 And Num1 < 8 Then

            If Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

                If Board(Num1 + 1, Num2) <> 0 And Board(Num1 - 1, Num2) <> 0 And Board(Num1, Num2 + 1) <> 0 And Board(Num1, Num2 - 1) <> 0 Then

                    MainEntranceSound.Play()

                    Try

                        If Board(Num1 + 2, Num2) = 0 Then

                            PieceToMove(Board(Num1 + 1, Num2)).Location = New Point(PieceToMove(Board(Num1 + 1, Num2)).Location.X, PieceToMove(Board(Num1 + 1, Num2)).Location.Y + 100)

                            Board(Num1 + 2, Num2) = Board(Num1 + 1, Num2)
                            Board(Num1 + 1, Num2) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 + 1, Num2) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 + 1, Num2)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 + 1, Num2)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 + 1, Num2)) = False

                            End If

                        ElseIf Board(Num1 + 1, Num2) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 + 1, Num2))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 + 1, Num2))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 + 1, Num2))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1 - 2, Num2) = 0 Then

                            PieceToMove(Board(Num1 - 1, Num2)).Location = New Point(PieceToMove(Board(Num1 - 1, Num2)).Location.X, PieceToMove(Board(Num1 - 1, Num2)).Location.Y - 100)

                            Board(Num1 - 2, Num2) = Board(Num1 - 1, Num2)
                            Board(Num1 - 1, Num2) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 - 1, Num2) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 - 1, Num2)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 - 1, Num2)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 - 1, Num2)) = False

                            End If

                        ElseIf Board(Num1 - 1, Num2) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 - 1, Num2))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 - 1, Num2))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 - 1, Num2))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, Num2 + 2) = 0 Then

                            PieceToMove(Board(Num1, Num2 + 1)).Location = New Point(PieceToMove(Board(Num1, Num2 + 1)).Location.X + 100, PieceToMove(Board(Num1, Num2 + 1)).Location.Y)

                            Board(Num1, Num2 + 2) = Board(Num1, Num2 + 1)
                            Board(Num1, Num2 + 1) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, Num2 + 1) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, Num2 + 1)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, Num2 + 1)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, Num2 + 1)) = False

                            End If

                        ElseIf Board(Num1, Num2 + 1) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, Num2 + 1))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, Num2 + 1))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, Num2 + 1))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, Num2 - 2) = 0 Then

                            PieceToMove(Board(Num1, Num2 - 1)).Location = New Point(PieceToMove(Board(Num1, Num2 - 1)).Location.X - 100, PieceToMove(Board(Num1, Num2 - 1)).Location.Y)

                            Board(Num1, Num2 - 2) = Board(Num1, Num2 - 1)
                            Board(Num1, Num2 - 1) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, Num2 - 1) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, Num2 - 1)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, Num2 - 1)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, Num2 - 1)) = False

                            End If

                        ElseIf Board(Num1, Num2 - 1) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, Num2 - 1))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, Num2 - 1))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, Num2 - 1))) = False

                            End If

                        End If

                    End Try

                ElseIf x = False Then

                    TakeSound.Play()

                ElseIf x = True Then

                    MoveSound.Play()

                End If

            ElseIf x = True Then

                MoveSound.Play()

            ElseIf x = False Then

                TakeSound.Play()

            End If

        ElseIf x = False Then

            TakeSound.Play()

        ElseIf x = True Then

            MoveSound.Play()

        End If

    End Sub

    Public Sub MainEntranceClmn2(x As Boolean, Num1 As Integer)

        Call KnightsHoodOff()

        If Num1 > 1 And Num1 < 8 Then

            If Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

                If Board(Num1 + 1, 2) <> 0 And Board(Num1 - 1, 2) <> 0 And Board(Num1, 3) <> 0 And Board(Num1, 1) <> 0 Then

                    MainEntranceSound.Play()

                    Try

                        If Board(Num1 + 2, 2) = 0 Then

                            PieceToMove(Board(Num1 + 1, 2)).Location = New Point(PieceToMove(Board(Num1 + 1, 2)).Location.X, PieceToMove(Board(Num1 + 1, 2)).Location.Y + 100)

                            Board(Num1 + 2, 2) = Board(Num1 + 1, 2)
                            Board(Num1 + 1, 2) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 + 1, 2) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 + 1, 2)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 + 1, 2)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 + 1, 2)) = False

                            End If

                        ElseIf Board(Num1 + 1, 2) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 + 1, 2))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 + 1, 2))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 + 1, 2))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1 - 2, 2) = 0 Then

                            PieceToMove(Board(Num1 - 1, 2)).Location = New Point(PieceToMove(Board(Num1 - 1, 2)).Location.X, PieceToMove(Board(Num1 - 1, 2)).Location.Y - 100)

                            Board(Num1 - 2, 2) = Board(Num1 - 1, 2)
                            Board(Num1 - 1, 2) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 - 1, 2) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 - 1, 2)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 - 1, 2)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 - 1, 2)) = False

                            End If

                        ElseIf Board(Num1 - 1, 2) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 - 1, 2))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 - 1, 2))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 - 1, 2))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 2 + 2) = 0 Then

                            PieceToMove(Board(Num1, 3)).Location = New Point(PieceToMove(Board(Num1, 3)).Location.X + 100, PieceToMove(Board(Num1, 3)).Location.Y)

                            Board(Num1, 2 + 2) = Board(Num1, 3)
                            Board(Num1, 3) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 3) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 3)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 3)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 3)) = False

                            End If

                        ElseIf Board(Num1, 3) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 3))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 3))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 3))) = False

                            End If

                        End If

                    End Try

                ElseIf x = False Then

                    TakeSound.Play()

                ElseIf x = True Then

                    MoveSound.Play()

                End If

            ElseIf x = False Then

                TakeSound.Play()

            ElseIf x = True Then

                MoveSound.Play()

            End If

        ElseIf x = False Then

            TakeSound.Play()

        ElseIf x = True Then

            MoveSound.Play()

        End If

    End Sub

    Public Sub MainEntranceClmn3(x As Boolean, Num1 As Integer)

        Call KnightsHoodOff()

        If Num1 > 1 And Num1 < 8 Then

            If Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

                If Board(Num1 + 1, 3) <> 0 And Board(Num1 - 1, 3) <> 0 And Board(Num1, 4) <> 0 And Board(Num1, 2) <> 0 Then

                    MainEntranceSound.Play()

                    Try

                        If Board(Num1 + 2, 3) = 0 Then

                            PieceToMove(Board(Num1 + 1, 3)).Location = New Point(PieceToMove(Board(Num1 + 1, 3)).Location.X, PieceToMove(Board(Num1 + 1, 3)).Location.Y + 100)

                            Board(Num1 + 2, 3) = Board(Num1 + 1, 3)
                            Board(Num1 + 1, 3) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 + 1, 3) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 + 1, 3)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 + 1, 3)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 + 1, 3)) = False

                            End If

                        ElseIf Board(Num1 + 1, 3) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 + 1, 3))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 + 1, 3))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 + 1, 3))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1 - 2, 3) = 0 Then

                            PieceToMove(Board(Num1 - 1, 3)).Location = New Point(PieceToMove(Board(Num1 - 1, 3)).Location.X, PieceToMove(Board(Num1 - 1, 3)).Location.Y - 100)

                            Board(Num1 - 2, 3) = Board(Num1 - 1, 3)
                            Board(Num1 - 1, 3) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 - 1, 3) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 - 1, 3)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 - 1, 3)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 - 1, 3)) = False

                            End If

                        ElseIf Board(Num1 - 1, 3) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 - 1, 3))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 - 1, 3))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 - 1, 3))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 5) = 0 Then

                            PieceToMove(Board(Num1, 4)).Location = New Point(PieceToMove(Board(Num1, 4)).Location.X + 100, PieceToMove(Board(Num1, 4)).Location.Y)

                            Board(Num1, 5) = Board(Num1, 4)
                            Board(Num1, 4) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 4) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 4)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 4)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 4)) = False

                            End If

                        ElseIf Board(Num1, 4) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 4))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 4))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 4))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 1) = 0 Then

                            If Abs(Board(Num1, 2)) >= 31 And Abs(Board(Num1, 2)) <= 33 Then

                                PieceToMove(Board(Num1, 2)).Location = New Point(PieceToMove(Board(Num1, 2)).Location.X - 110, PieceToMove(Board(Num1, 2)).Location.Y)

                                Call KnightsHoodOn(Board(Num1, 2))

                                Board(Num1, 1) = Board(Num1, 2)
                                Board(Num1, 2) = 0

                            Else

                                If Board(Num1, 2) < 0 Then

                                    If Board(Num1, 2) <= -11 And Board(Num1, 2) >= -18 Then

                                        NumberOfBlackPawns -= 1

                                    End If

                                    Call RemoveBlackPieceFromBoard(PieceToMove(Board(Num1, 2)))

                                ElseIf Board(Num1, 2) > 0 Then

                                    If Board(Num1, 2) >= 11 And Board(Num1, 2) <= 18 Then

                                        NumberOfWhitePawns -= 1

                                    End If

                                    Call RemoveWhitePieceFromBoard(PieceToMove(Board(Num1, 2)))

                                End If

                                Board(Num1, 2) = 0

                            End If

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 2) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 2)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 2)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 2)) = False

                            End If

                        ElseIf Board(Num1, 2) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 2))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 2))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 2))) = False

                            End If

                        End If

                    End Try

                ElseIf x = False Then

                    TakeSound.Play()

                ElseIf x = True Then

                    MoveSound.Play()

                End If

            ElseIf x = False Then

                TakeSound.Play()

            ElseIf x = True Then

                MoveSound.Play()

            End If

        ElseIf x = False Then

            TakeSound.Play()

        ElseIf x = True Then

            MoveSound.Play()

        End If

    End Sub

    Public Sub MainEntranceClmn8(x As Boolean, Num1 As Integer)

        Call KnightsHoodOff()

        If Num1 > 1 And Num1 < 8 Then

            If Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

                If Board(Num1 + 1, 8) <> 0 And Board(Num1 - 1, 8) <> 0 And Board(Num1, 9) <> 0 And Board(Num1, 7) <> 0 Then

                    MainEntranceSound.Play()

                    Try

                        If Board(Num1 + 2, 8) = 0 Then

                            PieceToMove(Board(Num1 + 1, 8)).Location = New Point(PieceToMove(Board(Num1 + 1, 8)).Location.X, PieceToMove(Board(Num1 + 1, 8)).Location.Y + 100)

                            Board(Num1 + 2, 8) = Board(Num1 + 1, 8)
                            Board(Num1 + 1, 8) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 + 1, 8) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 + 1, 8)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 + 1, 8)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 + 1, 8)) = False

                            End If

                        ElseIf Board(Num1 + 1, 8) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 + 1, 8))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 + 1, 8))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 + 1, 8))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1 - 2, 8) = 0 Then

                            PieceToMove(Board(Num1 - 1, 8)).Location = New Point(PieceToMove(Board(Num1 - 1, 8)).Location.X, PieceToMove(Board(Num1 - 1, 8)).Location.Y + 100)

                            Board(Num1 - 2, 8) = Board(Num1 - 1, 8)
                            Board(Num1 - 1, 8) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 - 1, 8) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 - 1, 8)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 - 1, 8)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 - 1, 8)) = False

                            End If

                        ElseIf Board(Num1 - 1, 8) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 - 1, 8))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 - 1, 8))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 - 1, 8))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 10) = 0 Then

                            If Abs(Board(Num1, 9)) >= 31 And Abs(Board(Num1, 9)) <= 33 Then

                                PieceToMove(Board(Num1, 9)).Location = New Point(PieceToMove(Board(Num1, 9)).Location.X + 110, PieceToMove(Board(Num1, 9)).Location.Y)

                                Call KnightsHoodOn(Board(Num1, 9))

                                Board(Num1, 10) = Board(Num1, 9)
                                Board(Num1, 9) = 0

                            Else

                                If Board(Num1, 9) < 0 Then

                                    BlackPiecesTaken += 1

                                    If Board(Num1, 9) <= -11 And Board(Num1, 9) >= -18 Then

                                        NumberOfBlackPawns -= 1

                                    End If

                                    If BlackPiecesTaken > 6 And BlackPiecesTaken <= 12 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (BlackPiecesTaken - 7) * 37, 543)

                                    ElseIf BlackPiecesTaken <= 6 And BlackPiecesTaken > 0 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (BlackPiecesTaken - 1) * 37, 506)

                                    ElseIf BlackPiecesTaken > 12 And BlackPiecesTaken <= 18 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (BlackPiecesTaken - 13) * 37, 580)

                                    End If

                                ElseIf Board(Num1, 9) > 0 Then

                                    WhitePiecesTaken += 1

                                    If Board(Num1, 9) >= 11 And Board(Num1, 9) <= 18 Then

                                        NumberOfWhitePawns -= 1

                                    End If

                                    If WhitePiecesTaken > 6 And WhitePiecesTaken <= 12 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (WhitePiecesTaken - 7) * 37, 128)

                                    ElseIf WhitePiecesTaken <= 6 And WhitePiecesTaken > 0 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (WhitePiecesTaken - 1) * 37, 91)

                                    ElseIf WhitePiecesTaken > 12 And WhitePiecesTaken <= 18 Then

                                        PieceToMove(Board(Num1, 9)).Location = New Point(27 + (WhitePiecesTaken - 13) * 37, 165)

                                    End If

                                End If

                            End If

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 9) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 9)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 9)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 9)) = False

                            End If

                        ElseIf Board(Num1, 9) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 9))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 9))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 9))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 6) = 0 Then

                            PieceToMove(Board(Num1, 7)).Location = New Point(PieceToMove(Board(Num1, 7)).Location.X - 100, PieceToMove(Board(Num1, 7)).Location.Y)

                            Board(Num1, 6) = Board(Num1, 7)
                            Board(Num1, 7) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 7) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 7)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 7)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 7)) = False

                            End If

                        ElseIf Board(Num1, 7) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 7))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 7))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 7))) = False

                            End If

                        End If

                    End Try

                ElseIf x = False Then

                    TakeSound.Play()

                ElseIf x = True Then

                    MoveSound.Play()

                End If

            ElseIf x = False Then

                TakeSound.Play()

            ElseIf x = True Then

                MoveSound.Play()

            End If

        ElseIf x = False Then

            TakeSound.Play()

        ElseIf x = True Then

            MoveSound.Play()

        End If

    End Sub

    Public Sub MainEntranceClmn9(x As Boolean, Num1 As Integer)

        Call KnightsHoodOff()

        If Num1 > 1 And Num1 < 8 Then

            If Abs(SelectedPiece) >= 31 And Abs(SelectedPiece) <= 33 Then

                If Board(Num1 + 1, 9) <> 0 And Board(Num1 + 1, 9) <> 0 And Board(Num1, 10) <> 0 And Board(Num1, 8) <> 0 Then

                    MainEntranceSound.Play()

                    Try

                        If Board(Num1 - 2, 9) = 0 Then

                            PieceToMove(Board(Num1 - 1, 9)).Location = New Point(PieceToMove(Board(Num1 - 1, 9)).Location.X, PieceToMove(Board(Num1 - 1, 9)).Location.Y - 100)

                            Board(Num1 - 2, 9) = Board(Num1 - 1, 9)
                            Board(Num1 - 1, 9) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 - 1, 9) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 - 1, 9)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 - 1, 9)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 - 1, 9)) = False

                            End If

                        ElseIf Board(Num1 - 1, 9) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 - 1, 9))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 - 1, 9))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 - 1, 9))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1 + 2, 9) = 0 Then

                            PieceToMove(Board(Num1 + 1, 9)).Location = New Point(PieceToMove(Board(Num1 + 1, 9)).Location.X, PieceToMove(Board(Num1 + 1, 9)).Location.Y + 100)

                            Board(Num1 + 2, 9) = Board(Num1 + 1, 9)
                            Board(Num1 + 1, 9) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1 + 1, 9) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1 + 1, 9)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1 + 1, 9)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1 + 1, 9)) = False

                            End If

                        ElseIf Board(Num1 + 1, 9) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1 + 1, 9))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1 + 1, 9))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1 + 1, 9))) = False

                            End If

                        End If

                    End Try

                    Try

                        If Board(Num1, 7) = 0 Then

                            PieceToMove(Board(Num1, 8)).Location = New Point(PieceToMove(Board(Num1, 8)).Location.X - 100, PieceToMove(Board(Num1, 8)).Location.Y)

                            Board(Num1, 7) = Board(Num1, 8)
                            Board(Num1, 8) = 0

                        Else

                            Board(11, 11) = 0   'Cause an error to enter the Catch section

                        End If

                    Catch ex As Exception

                        If Board(Num1, 8) > 0 Then

                            If SelectedPiece = -31 Then

                                TakeBlackKnight1Elig(Board(Num1, 8)) = False

                            ElseIf SelectedPiece = -32 Then

                                TakeBlackKnight2Elig(Board(Num1, 8)) = False

                            ElseIf SelectedPiece = -33 Then

                                TakeBlackKnight3Elig(Board(Num1, 8)) = False

                            End If

                        ElseIf Board(Num1, 8) < 0 Then

                            If SelectedPiece = 31 Then

                                TakeWhiteKnight1Elig(Abs(Board(Num1, 8))) = False

                            ElseIf SelectedPiece = 32 Then

                                TakeWhiteKnight2Elig(Abs(Board(Num1, 8))) = False

                            ElseIf SelectedPiece = 33 Then

                                TakeWhiteKnight3Elig(Abs(Board(Num1, 8))) = False

                            End If

                        End If

                    End Try

                ElseIf x = False Then

                    TakeSound.Play()

                ElseIf x = True Then

                    MoveSound.Play()

                End If

            ElseIf x = False Then

                TakeSound.Play()

            ElseIf x = True Then

                MoveSound.Play()

            End If

        ElseIf x = False Then

            TakeSound.Play()

        ElseIf x = True Then

            MoveSound.Play()

        End If

    End Sub

    Public Sub MainEntranceOnDeath(counter1, counter2)

        If counter2 = 2 Then

            Call MainEntranceClmn2(False, counter1)

        ElseIf counter2 = 3 Then

            Call MainEntranceClmn3(False, counter1)

        ElseIf counter2 = 8 Then

            Call MainEntranceClmn8(False, counter1)

        ElseIf counter2 = 9 Then

            Call MainEntranceClmn9(False, counter1)

        Else

            Call MainEntranceMidClmns(False, counter1, counter2)

        End If

    End Sub

    'Queen's Advantage

    Public Sub WhiteQueensAdv()

        For counter1 = 8 To 1 Step -1

            For counter2 = 2 To 9

                If Board(counter1, counter2) = 0 Then

                    Temp1 += 1

                    If Temp1 = 1 Then

                        QueensAdvRow = counter1

                    End If

                End If

            Next

        Next

        Temp1 = 0

        For counter = 2 To 9

            If Board(QueensAdvRow, counter) = 0 Then

                Temp1 += 1
                Temp2 += 1
                QueensAdvClmns(Temp1) = counter

            End If

        Next

        If Temp1 = 1 Then

            QueensAdCycleSound.Play()

            WhiteQueen1.Size = New Size(100, 100)

            LastTakenPieceWhite.Location = New Point(WhiteQueen1.Location)

            WhiteQueen1.Location = New Point((QueensAdvClmns(Temp1) + 1.9) * 100, (QueensAdvRow - 0.8) * 100)

            Board(QueensAdvRow, QueensAdvClmns(Temp1)) = 51

            WhiteQueen1Alive = True

            Temp1 = 0
            Temp2 = 0
            Temp3 = 0
            QueensAdvRow = 0
            QueensAdvClmns(1) = 0

            WhitePiecesTaken -= 1

        Else

            Temp1 = 1

            Timer3.Start()

            LastTakenPieceWhite.Location = New Point(WhiteQueen1.Location)

        End If

    End Sub

    Public Sub BlackQueensAdv()

        For counter1 = 1 To 8

            For counter2 = 2 To 9

                If Board(counter1, counter2) = 0 Then

                    Temp1 += 1

                    If Temp1 = 1 Then

                        QueensAdvRow = counter1

                    End If

                End If

            Next

        Next

        Temp1 = 0

        For counter = 2 To 9

            If Board(QueensAdvRow, counter) = 0 Then

                Temp1 += 1
                Temp2 += 1
                QueensAdvClmns(Temp1) = counter

            End If

        Next

        If Temp1 = 1 Then

            QueensAdCycleSound.Play()

            BlackQueen1.Size = New Size(100, 100)

            LastTakenPieceBlack.Location = New Point(BlackQueen1.Location)

            BlackQueen1.Location = New Point((QueensAdvClmns(Temp1) + 1.9) * 100, (QueensAdvRow - 0.8) * 100)

            Board(QueensAdvRow, QueensAdvClmns(Temp1)) = 51

            BlackQueen1Alive = True

            Temp1 = 0
            Temp2 = 0
            Temp3 = 0
            QueensAdvRow = 0
            QueensAdvClmns(1) = 0

            BlackPiecesTaken -= 1

        Else

            Temp1 = 1

            Timer4.Start()

            LastTakenPieceBlack.Location = New Point(BlackQueen1.Location)

        End If

    End Sub

    'Bishop's Rage

    Public Sub BishopsRageWhite(counter1 As Integer, counter2 As Integer)

        BishopsRageElig = False

        Try

            If Board(counter1 + 1, counter2 + 1) >= -33 And Board(counter1 + 1, counter2 + 1) <= -31 Then

                BishopsRageElig = True

                Call RemoveBlackPieceFromBoard(PieceToMove(Board(counter1 + 1, counter2 + 1)))

                Board(counter1 + 1, counter2 + 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 1) >= -33 And Board(counter1 - 1, counter2 + 1) <= -31 Then

                BishopsRageElig = True

                Call RemoveBlackPieceFromBoard(PieceToMove(Board(counter1 - 1, counter2 + 1)))

                Board(counter1 - 1, counter2 + 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 1) >= -33 And Board(counter1 + 1, counter2 - 1) <= -31 Then

                BishopsRageElig = True

                Call RemoveBlackPieceFromBoard(PieceToMove(Board(counter1 + 1, counter2 - 1)))

                Board(counter1 + 1, counter2 - 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 1) >= -33 And Board(counter1 - 1, counter2 - 1) <= -31 Then

                BishopsRageElig = True

                Call RemoveBlackPieceFromBoard(PieceToMove(Board(counter1 - 1, counter2 - 1)))

                Board(counter1 - 1, counter2 - 1) = 0

            End If

        Catch ex As Exception

        End Try

        If BishopsRageElig = True Then

            BishopsRageSound.Play()

            Call BlackTurnSub()
            Call InitialImageForBlack()
            Call InitialImageForWhite()
            Call HideAllPossibleMoves()
            Call DefaultCursorForWhite()
            Call HandCursorForBlack()

        End If

    End Sub

    Public Sub BishopsRageBlack(counter1 As Integer, counter2 As Integer)

        BishopsRageElig = False

        Try

            If Board(counter1 + 1, counter2 + 1) >= 31 And Board(counter1 + 1, counter2 + 1) <= 33 Then

                BishopsRageElig = True

                Call RemoveWhitePieceFromBoard(PieceToMove(Board(counter1 + 1, counter2 + 1)))

                Board(counter1 + 1, counter2 + 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 1) >= 31 And Board(counter1 - 1, counter2 + 1) <= 33 Then

                BishopsRageElig = True

                Call RemoveWhitePieceFromBoard(PieceToMove(Board(counter1 - 1, counter2 + 1)))

                Board(counter1 - 1, counter2 + 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 1) >= 31 And Board(counter1 + 1, counter2 - 1) <= 33 Then

                BishopsRageElig = True

                Call RemoveWhitePieceFromBoard(PieceToMove(Board(counter1 + 1, counter2 - 1)))

                Board(counter1 + 1, counter2 - 1) = 0

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 1) >= 31 And Board(counter1 - 1, counter2 - 1) <= 33 Then

                BishopsRageElig = True

                Call RemoveWhitePieceFromBoard(PieceToMove(Board(counter1 - 1, counter2 - 1)))

                Board(counter1 - 1, counter2 - 1) = 0

            End If

        Catch ex As Exception

        End Try

        If BishopsRageElig = True Then

            BishopsRageSound.Play()

            Call WhiteTurnSub()
            Call InitialImageForBlack()
            Call InitialImageForWhite()
            Call HideAllPossibleMoves()
            Call DefaultCursorForBlack()
            Call HandCursorForWhite()

        End If

    End Sub

    'Turn Subs

    Public Sub WhiteTurnSub()

        Call ResetBlackEnPassant()

        ParalysedBlackQueen(1) = False
        ParalysedBlackQueen(2) = False

        SeventyFiveMoveRule -= 1

        If SeventyFiveMoveRule = 25 Then

            GameEndsSound.Play()
            MsgBox("Draw by 50-Move Rule Eligible!")

        ElseIf SeventyFiveMoveRule = 0 Then

            GameEndsSound.Play()
            MsgBox("Draw by 75-Move Rule!")
            Me.Close()

        End If

        If KingsExCooldownBlack > 1 Then

            KingsExCooldownBlack -= 1

            Label11.Text = KingsExCooldownBlack & " Moves"

        ElseIf KingsExCooldownBlack = 1 Then

            KingsExCooldownBlack -= 1

            KingsExBlack.Enabled = False

            Label11.Text = "Ready"

        ElseIf KingsExCooldownBlack = 0 Then

            KingsExBlack.Enabled = False

        End If

        If KingsExCooldownWhite = 0 Then

            KingsExWhite.Enabled = True

        End If

        WhiteTurn = True
        WhiteTurnBorder.Visible = True
        BlackTurnBorder.Visible = False

        Timer1.Start()
        Timer2.Stop()

        If BlackQueen1Alive = False Then

            BlackQATTC = Form2.QAT

            QATBlack.Start()

        End If

        If WhiteQueen1Alive = False Then

            QATWhite.Stop()

            If Form2.QAT = 60 Then

                Label12.Text = "01:00"

            Else

                Label12.Text = "00:" & Form2.QAT

            End If

        End If

    End Sub

    Public Sub BlackTurnSub()

        Call ResetWhiteEnPassant()

        ParalysedWhiteQueen(1) = False
        ParalysedWhiteQueen(2) = False

        If KingsExCooldownWhite > 1 Then

            KingsExCooldownWhite -= 1

            Label16.Text = KingsExCooldownWhite & " Moves"

        ElseIf KingsExCooldownWhite = 1 Then

            KingsExCooldownWhite -= 1

            KingsExWhite.Enabled = False

            Label16.Text = "Ready"

        ElseIf KingsExCooldownWhite = 0 Then

            KingsExWhite.Enabled = False

        End If

        If KingsExCooldownBlack = 0 Then

            KingsExBlack.Enabled = True

        End If

        WhiteTurn = False
        WhiteTurnBorder.Visible = False
        BlackTurnBorder.Visible = True

        Timer1.Stop()
        Timer2.Start()

        If WhiteQueen1Alive = False Then

            WhiteQATTC = Form2.QAT

            QATWhite.Start()

        End If

        If BlackQueen1Alive = False Then

            QATBlack.Stop()

            If Form2.QAT = 60 Then

                Label10.Text = "01:00"

            Else

                Label10.Text = "00:" & Form2.QAT

            End If

        End If

    End Sub

    'Piece Movement

    Public Sub WhitePawnMovement(counter1 As Integer, counter2 As Integer)

        If Board(counter1 - 1, counter2) = 0 Then

            Call ShowAllPossibleMoves((counter2 * 10) + counter1 - 1)

        End If

        If counter1 = 7 Then

            If Board(counter1 - 2, counter2) = 0 And Board(counter1 - 1, counter2) = 0 Then

                Call ShowAllPossibleMoves((counter2 * 10) + counter1 - 2)

            End If

        End If

        If Board(counter1, counter2 + 1) = 0 And counter2 <> 9 Then

            Call ShowAllPossibleMoves(((counter2 + 1) * 10) + counter1)

        End If

        If Board(counter1, counter2 - 1) = 0 And counter2 <> 2 Then

            Call ShowAllPossibleMoves(((counter2 - 1) * 10) + counter1)

        End If

        If Board(counter1 - 1, counter2 + 1) < 0 Then

            Call ThreatenedPieces(Board(counter1 - 1, counter2 + 1))

        End If

        If Board(counter1 - 1, counter2 - 1) < 0 Then

            Call ThreatenedPieces(Board(counter1 - 1, counter2 - 1))

        End If

    End Sub

    Public Sub BlackPawnMovement(counter1 As Integer, counter2 As Integer)

        If counter1 <> 8 Then

            If Board(counter1 + 1, counter2) = 0 Then

                Call ShowAllPossibleMoves((counter2 * 10) + counter1 + 1)

            End If

            If Board(counter1 + 1, counter2 - 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 - 1))

            End If

            If Board(counter1 + 1, counter2 + 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 + 1))

            End If

        End If

        If counter1 = 2 Then

            If Board(counter1 + 2, counter2) = 0 And Board(counter1 + 1, counter2) = 0 Then

                Call ShowAllPossibleMoves((counter2 * 10) + counter1 + 2)

            End If

        End If

        If Board(counter1, counter2 + 1) = 0 And counter2 <> 9 Then

            Call ShowAllPossibleMoves(((counter2 + 1) * 10) + counter1)

        End If

        If Board(counter1, counter2 - 1) = 0 And counter2 <> 2 Then

            Call ShowAllPossibleMoves(((counter2 - 1) * 10) + counter1)

        End If

    End Sub

    Public Sub DiagonalRookMovement(counter1 As Integer, counter2 As Integer)

        Try

            If Board(counter1 + 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 + 1)

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 + 1)

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 - 1)

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 - 1)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WhiteRookieMovement(counter1 As Integer, counter2 As Integer)

        Try

            For counter3 = 1 To 7

                If Board(counter1, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1)

                Else

                    If Board(counter1, counter2 + counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1)

                Else

                    If Board(counter1, counter2 - counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2) = 0 Then

                    Call ShowAllPossibleMoves(counter2 * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2) < 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2) = 0 Then

                    Call ShowAllPossibleMoves((counter2) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2) < 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub BlackRookieMovement(counter1 As Integer, counter2 As Integer)

        Try

            For counter3 = 1 To 7

                If Board(counter1, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1)

                Else

                    If Board(counter1, counter2 + counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1)

                Else

                    If Board(counter1, counter2 - counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2) = 0 Then

                    Call ShowAllPossibleMoves(counter2 * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2) > 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2) = 0 Then

                    Call ShowAllPossibleMoves((counter2) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2) > 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WhiteKnightMovement(counter1, counter2)

        Try

            If Board(counter1 - 2, counter2 + 1) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 - 2)

            ElseIf Board(counter1 - 2, counter2 + 1) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 - 2, counter2 + 1) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 - 2, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 2, counter2 - 1) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 - 2)

            ElseIf Board(counter1 - 2, counter2 - 1) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 - 2, counter2 - 1) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 - 2, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 2) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 + 2) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 + 2) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 - 1, counter2 + 2) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 + 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 2) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 - 2) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 - 2) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 - 1, counter2 - 2) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 - 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 + 2) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 + 2) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 + 2) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 + 1, counter2 + 2) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 + 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 2) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 - 2) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 - 2) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 + 1, counter2 - 2) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 - 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 2, counter2 + 1) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 + 2)

            ElseIf Board(counter1 + 2, counter2 + 1) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 + 2, counter2 + 1) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 + 2, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 2, counter2 - 1) = 0 And Floor(SelectedPiece / 10) = 3 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 + 2)

            ElseIf Board(counter1 + 2, counter2 - 1) < 0 And Floor(SelectedPiece / 10) = 3 Or Floor(SelectedPiece / 10) = 5 And Ceiling(Board(counter1 + 2, counter2 - 1) / 10) = -3 Then

                Call ThreatenedPieces(Board(counter1 + 2, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub BlackKnightMovement(counter1, counter2)

        Try

            If Board(counter1 - 2, counter2 + 1) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 - 2)

            ElseIf Board(counter1 - 2, counter2 + 1) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 - 2, counter2 + 1) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 - 2, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 2, counter2 - 1) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 - 2)

            ElseIf Board(counter1 - 2, counter2 - 1) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 - 2, counter2 - 1) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 - 2, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 2) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 + 2) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 + 2) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 - 1, counter2 + 2) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 + 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 2) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 - 2) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 - 2) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 - 1, counter2 - 2) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 - 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 + 2) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 + 2) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 + 2) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 + 1, counter2 + 2) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 + 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 2) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 - 2) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 - 2) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 + 1, counter2 - 2) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 - 2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 2, counter2 + 1) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 + 2)

            ElseIf Board(counter1 + 2, counter2 + 1) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 + 2, counter2 + 1) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 + 2, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 2, counter2 - 1) = 0 And Ceiling(SelectedPiece / 10) = -3 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 + 2)

            ElseIf Board(counter1 + 2, counter2 - 1) > 0 And Ceiling(SelectedPiece / 10) = -3 Or Ceiling(SelectedPiece / 10) = -5 And Floor(Board(counter1 + 2, counter2 - 1) / 10) = 3 Then

                Call ThreatenedPieces(Board(counter1 + 2, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WhiteBishopMovement(counter1, counter2)

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2 + counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Bottom-right

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2 - counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Bottom-left

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2 + counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Top-right

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2 - counter3) < 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Top-left

    End Sub

    Public Sub BlackBishopMovement(counter1, counter2)

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2 + counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Bottom-right

        Try

            For counter3 = 1 To 7

                If Board(counter1 + counter3, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1 + counter3)

                Else

                    If Board(counter1 + counter3, counter2 - counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1 + counter3, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Bottom-left

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2 + counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 + counter3) * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2 + counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2 + counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Top-right

        Try

            For counter3 = 1 To 7

                If Board(counter1 - counter3, counter2 - counter3) = 0 Then

                    Call ShowAllPossibleMoves((counter2 - counter3) * 10 + counter1 - counter3)

                Else

                    If Board(counter1 - counter3, counter2 - counter3) > 0 Then

                        Call ThreatenedPieces(Board(counter1 - counter3, counter2 - counter3))

                    End If

                    Exit For

                End If

            Next

        Catch ex As Exception

        End Try    'Top-left

    End Sub

    Public Sub WhiteKingMovement(counter1, counter2)

        Try

            If Board(counter1 + 1, counter2) = 0 Then

                Call ShowAllPossibleMoves(counter2 * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2) < 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2) = 0 Then

                Call ShowAllPossibleMoves(counter2 * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2) < 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1)

            ElseIf Board(counter1, counter2 + 1) < 0 Then

                Call ThreatenedPieces(Board(counter1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1)

            ElseIf Board(counter1, counter2 - 1) < 0 Then

                Call ThreatenedPieces(Board(counter1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 + 1) < 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 + 1) < 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 - 1) < 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 - 1) < 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub BlackKingMovement(counter1, counter2)

        Try

            If Board(counter1 + 1, counter2) = 0 Then

                Call ShowAllPossibleMoves(counter2 * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2) > 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2) = 0 Then

                Call ShowAllPossibleMoves(counter2 * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2) > 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1)

            ElseIf Board(counter1, counter2 + 1) > 0 Then

                Call ThreatenedPieces(Board(counter1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1)

            ElseIf Board(counter1, counter2 - 1) > 0 Then

                Call ThreatenedPieces(Board(counter1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 + 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 + 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 + 1) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 + 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 + 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 + 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 + 1)

            ElseIf Board(counter1 + 1, counter2 - 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 + 1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

        Try

            If Board(counter1 - 1, counter2 - 1) = 0 Then

                Call ShowAllPossibleMoves((counter2 - 1) * 10 + counter1 - 1)

            ElseIf Board(counter1 - 1, counter2 - 1) > 0 Then

                Call ThreatenedPieces(Board(counter1 - 1, counter2 - 1))

            End If

        Catch ex As Exception

        End Try

    End Sub

    'Remove Piece From Board

    Public Sub RemoveWhitePieceFromBoard(Piece As PictureBox)

        SeventyFiveMoveRule = 75

        Piece.Size = New Size(31, 31)

        LastTakenPieceWhite = Piece

        WhitePiecesTaken += 1

        If WhitePiecesTaken > 6 And WhitePiecesTaken <= 12 Then

            Piece.Location = New Point(27 + (WhitePiecesTaken - 7) * 37, 128)

        ElseIf WhitePiecesTaken <= 6 And WhitePiecesTaken > 0 Then

            Piece.Location = New Point(27 + (WhitePiecesTaken - 1) * 37, 91)

        ElseIf WhitePiecesTaken > 12 And WhitePiecesTaken <= 18 Then

            Piece.Location = New Point(27 + (WhitePiecesTaken - 13) * 37, 165)

        End If

    End Sub

    Public Sub RemoveBlackPieceFromBoard(Piece As PictureBox)

        SeventyFiveMoveRule = 75

        Piece.Size = New Size(31, 31)

        LastTakenPieceBlack = Piece

        BlackPiecesTaken += 1

        If BlackPiecesTaken > 6 And BlackPiecesTaken <= 12 Then

            Piece.Location = New Point(27 + (BlackPiecesTaken - 7) * 37, 543)

        ElseIf BlackPiecesTaken <= 6 And BlackPiecesTaken > 0 Then

            Piece.Location = New Point(27 + (BlackPiecesTaken - 1) * 37, 506)

        ElseIf BlackPiecesTaken > 12 And BlackPiecesTaken <= 18 Then

            Piece.Location = New Point(27 + (BlackPiecesTaken - 13) * 37, 580)

        End If

    End Sub

    Public Sub ClearInitialLocation()

        For counter1 = 1 To 8

            For counter2 = 1 To 10

                If Board(counter1, counter2) = SelectedPiece Then

                    Board(counter1, counter2) = 0

                End If

            Next

        Next

    End Sub

    'King's Exchange Subs

    Public Sub KingsExAvailPiecesBlack()

        If BlackPawn1.Size.Height = 100 Then

            BlackPawn1.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn2.Size.Height = 100 Then

            BlackPawn2.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn3.Size.Height = 100 Then

            BlackPawn3.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn4.Size.Height = 100 Then

            BlackPawn4.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn5.Size.Height = 100 Then

            BlackPawn5.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn6.Size.Height = 100 Then

            BlackPawn6.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn7.Size.Height = 100 Then

            BlackPawn7.Image = My.Resources.King_s_Ex

        End If

        If BlackPawn8.Size.Height = 100 Then

            BlackPawn8.Image = My.Resources.King_s_Ex

        End If

        If BlackRook1.Size.Height = 100 Then

            BlackRook1.Image = My.Resources.King_s_Ex

        End If

        If BlackRook2.Size.Height = 100 Then

            BlackRook2.Image = My.Resources.King_s_Ex

        End If

        If BlackKnight1.Size.Height = 100 And BlackKnight1.Location.X <> 280 And BlackKnight1.Location.X <> 1200 Then

            BlackKnight1.Image = My.Resources.King_s_Ex

        End If

        If BlackKnight2.Size.Height = 100 And BlackKnight2.Location.X <> 280 And BlackKnight2.Location.X <> 1200 Then

            BlackKnight2.Image = My.Resources.King_s_Ex

        End If

        If BlackKnight3.Size.Height = 100 And BlackKnight3.Location.X <> 280 And BlackKnight3.Location.X <> 1200 Then

            BlackKnight3.Image = My.Resources.King_s_Ex

        End If

        If BlackBishop1.Size.Height = 100 Then

            BlackBishop1.Image = My.Resources.King_s_Ex

        End If

        If BlackBishop2.Size.Height = 100 Then

            BlackBishop2.Image = My.Resources.King_s_Ex

        End If

        If BlackQueen1.Size.Height = 100 Then

            BlackQueen1.Image = My.Resources.King_s_Ex

        End If

        If BlackQueen2.Size.Height = 100 Then

            BlackQueen2.Image = My.Resources.King_s_Ex

        End If

        If BlackRookie1.Size.Height = 100 Then

            BlackRookie1.Image = My.Resources.King_s_Ex

        End If

        If BlackRookie2.Size.Height = 100 Then

            BlackRookie2.Image = My.Resources.King_s_Ex

        End If

    End Sub

    Public Sub KingsExAvailPiecesWhite()

        If WhitePawn1.Size.Height = 100 Then

            WhitePawn1.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn2.Size.Height = 100 Then

            WhitePawn2.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn3.Size.Height = 100 Then

            WhitePawn3.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn4.Size.Height = 100 Then

            WhitePawn4.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn5.Size.Height = 100 Then

            WhitePawn5.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn6.Size.Height = 100 Then

            WhitePawn6.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn7.Size.Height = 100 Then

            WhitePawn7.Image = My.Resources.King_s_Ex

        End If

        If WhitePawn8.Size.Height = 100 Then

            WhitePawn8.Image = My.Resources.King_s_Ex

        End If

        If WhiteRook1.Size.Height = 100 Then

            WhiteRook1.Image = My.Resources.King_s_Ex

        End If

        If WhiteRook2.Size.Height = 100 Then

            WhiteRook2.Image = My.Resources.King_s_Ex

        End If

        If WhiteKnight1.Size.Height = 100 And WhiteKnight1.Location.X <> 280 And WhiteKnight1.Location.X <> 1200 Then

            WhiteKnight1.Image = My.Resources.King_s_Ex

        End If

        If WhiteKnight2.Size.Height = 100 And WhiteKnight2.Location.X <> 280 And WhiteKnight2.Location.X <> 1200 Then

            WhiteKnight2.Image = My.Resources.King_s_Ex

        End If

        If WhiteKnight3.Size.Height = 100 And WhiteKnight3.Location.X <> 280 And WhiteKnight3.Location.X <> 1200 Then

            WhiteKnight3.Image = My.Resources.King_s_Ex

        End If

        If WhiteBishop1.Size.Height = 100 Then

            WhiteBishop1.Image = My.Resources.King_s_Ex

        End If

        If WhiteBishop2.Size.Height = 100 Then

            WhiteBishop2.Image = My.Resources.King_s_Ex

        End If

        If WhiteQueen1.Size.Height = 100 Then

            WhiteQueen1.Image = My.Resources.King_s_Ex

        End If

        If WhiteQueen2.Size.Height = 100 Then

            WhiteQueen2.Image = My.Resources.King_s_Ex

        End If

        If WhiteRookie1.Size.Height = 100 Then

            WhiteRookie1.Image = My.Resources.King_s_Ex

        End If

        If WhiteRookie2.Size.Height = 100 Then

            WhiteRookie2.Image = My.Resources.King_s_Ex

        End If

    End Sub

    Public Sub KingsExchangeBlack(Num As Integer, Piece As PictureBox)

        TempLocation = BlackKing.Location
        BlackKing.Location = Piece.Location
        Piece.Location = TempLocation

        LongCastleBlack = False
        ShortCastleBlack = False

        KingsExBlack.Visible = True
        KingsExBlack.Enabled = False
        CancelBlackKingEx.Visible = False

        Call InitialImageForBlack()
        Call WhiteTurnSub()
        Call DefaultCursorForBlack()
        Call HandCursorForWhite()

        KingsExStatusBlack = False
        KingsExCooldownBlack = 7
        Label11.Text = KingsExCooldownBlack & " Moves"

        For counter1 = 1 To 8

            For counter2 = 1 To 10

                If Board(counter1, counter2) = Num Then

                    For counter3 = 1 To 8

                        For counter4 = 1 To 10

                            If Board(counter3, counter4) = -60 Then

                                Board(counter3, counter4) = Num
                                Board(counter1, counter2) = -60

                                Exit Sub

                            End If

                        Next

                    Next

                End If

            Next

        Next

    End Sub

    Public Sub KingsExchangeWhite(Num As Integer, Piece As PictureBox)

        TempLocation = WhiteKing.Location
        WhiteKing.Location = Piece.Location
        Piece.Location = TempLocation

        LongCastleWhite = False
        ShortCastleWhite = False

        KingsExWhite.Visible = True
        KingsExWhite.Enabled = False
        CancelWhiteKingEx.Visible = False

        Call InitialImageForWhite()
        Call BlackTurnSub()
        Call DefaultCursorForWhite()
        Call HandCursorForBlack()

        KingsExStatusWhite = False
        KingsExCooldownWhite = 7
        Label16.Text = KingsExCooldownWhite & " Moves"

        For counter1 = 1 To 8

            For counter2 = 1 To 10

                If Board(counter1, counter2) = Num Then

                    For counter3 = 1 To 8

                        For counter4 = 1 To 10

                            If Board(counter3, counter4) = 60 Then

                                Board(counter3, counter4) = Num
                                Board(counter1, counter2) = 60

                                Exit Sub

                            End If

                        Next

                    Next

                End If

            Next

        Next

    End Sub

    'Pawns

    Private Sub WhitePawn1_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn1.Click

        If e.Button = MouseButtons.Left And WhitePawn1.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(11, WhitePawn1)

                MoveSound.Play()

            Else

                If WhiteTurn = True And WhitePawn1.Size.Height = 100 Then

                    Call DefaultCursorForBlack()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call HideAllPossibleMoves()

                    SelectedPiece = 11

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 11 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 11 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn1.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 11 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn1)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 11 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 11 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True

                        WhiteKnight3.Location = New Point(WhitePawn1.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn1)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 11 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn2_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn2.Click

        If e.Button = MouseButtons.Left And WhitePawn2.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(12, WhitePawn2)

                MoveSound.Play()

            Else

                If WhiteTurn = True And WhitePawn2.Size.Height = 100 Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 12

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 12 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 12 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn2.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 12 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        WhitePiecesTaken -= 1

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn2)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 12 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 12 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn2.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn2)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 12 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn3_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn3.Click

        If e.Button = MouseButtons.Left And WhitePawn3.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn3.Size.Height = 100 Then

                Call KingsExchangeWhite(13, WhitePawn3)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 13

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 13 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn3.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 13 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn3.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call WhiteTurnSub()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn3)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn3.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 13 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn3)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 13 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 13 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn3.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn3)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 13 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn4_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn4.Click

        If e.Button = MouseButtons.Left And WhitePawn4.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn4.Size.Height = 100 Then

                Call KingsExchangeWhite(14, WhitePawn4)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 14

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 14 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn4.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 14 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn4.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn4)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn4.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 14 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn4)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 14 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 14 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn4.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn4)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 14 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn5_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn5.Click

        If e.Button = MouseButtons.Left And WhitePawn5.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn1.Size.Height = 100 Then

                Call KingsExchangeWhite(15, WhitePawn5)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 15

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 15 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn5.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 15 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn5.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call WhiteTurnSub()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn5)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn5.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 15 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        NumberOfWhitePawns -= 1

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn5)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                    ElseIf Board(counter1, counter2) = 15 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 15 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn5.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn5)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 15 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn6_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn6.Click

        If e.Button = MouseButtons.Left And WhitePawn6.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn6.Size.Height = 100 Then

                Call KingsExchangeWhite(16, WhitePawn6)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 16

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 16 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn6.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 16 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn6.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call WhiteTurnSub()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn6)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn6.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 16 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn6)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 16 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 16 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn6.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn6)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 16 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn7_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn7.Click

        If e.Button = MouseButtons.Left And WhitePawn7.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn7.Size.Height = 100 Then

                Call KingsExchangeWhite(17, WhitePawn7)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 17

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 17 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn7.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 17 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn7.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn7)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn7.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 17 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn7)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 17 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 17 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn7.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn7)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 17 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub WhitePawn8_Click(sender As Object, e As MouseEventArgs) Handles WhitePawn8.Click

        If e.Button = MouseButtons.Left And WhitePawn8.Size.Height = 100 Then

            If KingsExStatusWhite = True And WhitePawn8.Size.Height = 100 Then

                Call KingsExchangeWhite(18, WhitePawn8)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 18

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 18 Then

                                Call WhitePawnMovement(counter1, counter2)
                                Call EnPassantBlackPositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhitePawn8.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfWhitePawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 18 Then

                                PieceToMove(SelectedPiece).Location = WhitePawn8.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call WhiteTurnSub()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhitePawn8)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhitePawn8.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = 18 And counter1 = 1 And (WhiteQueen1.Size.Height <> 100 Or WhiteQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveWhiteQueen(counter1, counter2)
                        Call RemoveWhitePieceFromBoard(WhitePawn8)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = False Then

                            Call HandCursorForBlack()
                            Call DefaultCursorForWhite()

                        End If

                        NumberOfWhitePawns -= 1

                    ElseIf Board(counter1, counter2) = 18 And counter1 <> 1 And counter1 <> 8 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = 18 And Board(counter1 - 1, counter2) <= 18 And Board(counter1 - 1, counter2) >= 11 And Board(counter1 + 1, counter2) <= 18 And Board(counter1 + 1, counter2) >= 11 Then

                            If WhiteTurn = True Then

                                Call DefaultCursorForBlack()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call WhiteFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = True And NumberOfWhitePawns = 1 Then

                        WhiteKnight3.Visible = True
                        WhiteKnight3.Location = New Point(WhitePawn8.Location)

                        PromotionSound.Play()

                        Call BlackTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForBlack()
                        Call DefaultCursorForWhite()
                        Call RemoveWhitePieceFromBoard(WhitePawn8)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = 18 Then

                                    Board(counter3, counter4) = 33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn1_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn1.Click

        If e.Button = MouseButtons.Left And BlackPawn1.Size.Height = 100 Then

            If KingsExStatusBlack = True And BlackPawn1.Size.Height = 100 Then

                Call KingsExchangeBlack(-11, BlackPawn1)

                MoveSound.Play()

            Else

                If WhiteTurn = False And BlackPawn1.Size.Height = 100 Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -11

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -11 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -11 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn1.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -11 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn1)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -11 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -11 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn1.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn1)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -11 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn2_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn2.Click

        If e.Button = MouseButtons.Left And BlackPawn2.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-12, BlackPawn2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -12

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -12 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -12 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn2.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -12 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn2)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -12 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -12 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn2.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn2)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -12 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn3_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn3.Click

        If e.Button = MouseButtons.Left And BlackPawn3.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-13, BlackPawn3)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -13

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -13 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn3.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    NumberOfBlackPawns -= 1

                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -13 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn3.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn3)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn3.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -13 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn3)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -13 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -13 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn3.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn3)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -13 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn4_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn4.Click

        If e.Button = MouseButtons.Left And BlackPawn4.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-14, BlackPawn4)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -14

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -14 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn4.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -14 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn4.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn4)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn4.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -14 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn4)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -14 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -14 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn4.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn4)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -14 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn5_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn5.Click

        If e.Button = MouseButtons.Left And BlackPawn5.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-15, BlackPawn5)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -15

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -15 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn5.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -15 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn5.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn5)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn5.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -15 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn5)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -15 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -15 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn5.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn5)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -15 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn6_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn6.Click

        If e.Button = MouseButtons.Left And BlackPawn6.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-16, BlackPawn6)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -16

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -16 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn6.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -16 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn6.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn6)

                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn6.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -16 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call HideAllPossibleMoves()
                        Call ReviveBlackQueen(counter1, counter2)
                        Call RemoveBlackPieceFromBoard(BlackPawn6)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -16 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -16 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn6.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn6)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -16 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn7_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn7.Click

        If e.Button = MouseButtons.Left And BlackPawn7.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-17, BlackPawn7)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -17

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -17 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn7.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -17 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn7.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn7)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn7.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -17 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call ReviveBlackQueen(counter1, counter2)
                        Call HideAllPossibleMoves()
                        Call RemoveBlackPieceFromBoard(BlackPawn7)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -17 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -17 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn7.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn7)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -17 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub BlackPawn8_Click(sender As Object, e As MouseEventArgs) Handles BlackPawn8.Click

        If e.Button = MouseButtons.Left Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-18, BlackPawn8)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -18

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -18 Then

                                Call BlackPawnMovement(counter1, counter2)
                                Call EnPassantWhitePositions(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackPawn8.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    NumberOfBlackPawns -= 1

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -18 Then

                                PieceToMove(SelectedPiece).Location = BlackPawn8.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call HideAllPossibleMoves()
                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackPawn8)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackPawn8.Size.Height = 100 Then

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = -18 And counter1 = 8 And (BlackQueen1.Size.Height <> 100 Or BlackQueen2.Size.Height <> 100) Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        Call ReviveBlackQueen(counter1, counter2)
                        Call HideAllPossibleMoves()
                        Call RemoveBlackPieceFromBoard(BlackPawn8)
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()

                        If WhiteTurn = True Then

                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()

                        End If

                        NumberOfBlackPawns -= 1

                    ElseIf Board(counter1, counter2) = -18 And counter1 <> 8 And counter1 <> 1 Then

                        TempLocation = PieceToMove(Board(counter1, counter2)).Location

                        If Board(counter1, counter2) = -18 And Board(counter1 - 1, counter2) >= -18 And Board(counter1 - 1, counter2) <= -11 And Board(counter1 + 1, counter2) >= -18 And Board(counter1 + 1, counter2) <= -11 Then

                            If WhiteTurn = False Then

                                Call DefaultCursorForWhite()

                            End If

                            Call InitialImageForBlack()
                            Call InitialImageForWhite()
                            Call HideAllPossibleMoves()
                            Call BlackFusion(counter1, counter2)

                        End If

                    ElseIf WhiteTurn = False And NumberOfBlackPawns = 1 Then

                        BlackKnight3.Visible = True
                        BlackKnight3.Location = New Point(BlackPawn8.Location)

                        PromotionSound.Play()

                        Call WhiteTurnSub()
                        Call HideAllPossibleMoves()
                        Call InitialImageForBlack()
                        Call InitialImageForWhite()
                        Call HandCursorForWhite()
                        Call DefaultCursorForBlack()
                        Call RemoveBlackPieceFromBoard(BlackPawn8)

                        For counter3 = 1 To 8

                            For counter4 = 1 To 10

                                If Board(counter3, counter4) = -18 Then

                                    Board(counter3, counter4) = -33

                                End If

                            Next

                        Next

                    End If

                Next

            Next

        End If

    End Sub

    'Rooks

    Private Sub WhiteRook1_Click(sender As Object, e As MouseEventArgs) Handles WhiteRook1.Click

        If e.Button = MouseButtons.Left And WhiteRook1.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(21, WhiteRook1)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 21

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 21 Then

                                Call WhiteRookieMovement(counter1, counter2)
                                Call DiagonalRookMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteRook1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    LongCastleWhite = False

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 21 Then

                                PieceToMove(SelectedPiece).location = WhiteRook1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteRook1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub WhiteRook2_Click(sender As Object, e As MouseEventArgs) Handles WhiteRook2.Click

        If e.Button = MouseButtons.Left And WhiteRook2.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(22, WhiteRook2)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 22

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 22 Then

                                Call DiagonalRookMovement(counter1, counter2)
                                Call WhiteRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteRook2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    ShortCastleWhite = False

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 22 Then

                                PieceToMove(SelectedPiece).location = WhiteRook2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteRook2)

                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackRook1_Click(sender As Object, e As MouseEventArgs) Handles BlackRook1.Click

        If e.Button = MouseButtons.Left And BlackRook1.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-21, BlackRook1)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -21

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -21 Then

                                Call DiagonalRookMovement(counter1, counter2)
                                Call BlackRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackRook1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    LongCastleBlack = False

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -21 Then

                                PieceToMove(SelectedPiece).Location = BlackRook1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackRook1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackRook2_Click(sender As Object, e As MouseEventArgs) Handles BlackRook2.Click

        If e.Button = MouseButtons.Left And BlackRook2.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-22, BlackRook2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -22

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -22 Then

                                Call DiagonalRookMovement(counter1, counter2)
                                Call BlackRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackRook2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    ShortCastleBlack = False

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -22 Then

                                PieceToMove(SelectedPiece).Location = BlackRook2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackRook2)
                                Call HideAllPossibleMoves()
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If


    End Sub

    'Rookies

    Private Sub WhiteRookie1_Click(sender As Object, e As MouseEventArgs) Handles WhiteRookie1.Click

        If e.Button = MouseButtons.Left And WhiteRookie1.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(71, WhiteRookie1)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 71

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 71 Then

                                Call WhiteRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteRookie1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 71 Then

                                PieceToMove(SelectedPiece).location = WhiteRookie1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteRookie1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub WhiteRookie2_Click(sender As Object, e As MouseEventArgs) Handles WhiteRookie2.Click

        If e.Button = MouseButtons.Left And WhiteRookie2.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(72, WhiteRookie2)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 72

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 72 Then

                                Call WhiteRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteRookie2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 72 Then

                                PieceToMove(SelectedPiece).location = WhiteRookie2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteRookie2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackRookie1_Click(sender As Object, e As MouseEventArgs) Handles BlackRookie1.Click

        If e.Button = MouseButtons.Left And BlackRookie1.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-71, BlackRookie1)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -71

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -71 Then

                                Call BlackRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackRookie1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -71 Then

                                PieceToMove(SelectedPiece).Location = BlackRookie1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackRookie1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackRookie2_Click(sender As Object, e As MouseEventArgs) Handles BlackRookie2.Click

        If e.Button = MouseButtons.Left And BlackRookie2.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-72, BlackRookie2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -72

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -72 Then

                                Call BlackRookieMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackRookie2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -72 Then

                                PieceToMove(SelectedPiece).Location = BlackRookie2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackRookie2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    'Knights

    Private Sub WhiteKnight1_Click(sender As Object, e As MouseEventArgs) Handles WhiteKnight1.Click

        If e.Button = MouseButtons.Left And WhiteKnight1.Size.Height = 100 Then

            If KingsExStatusWhite = True And Abs(WhiteKnight1.Location.X - 740) <> 460 Then

                Call KingsExchangeWhite(31, WhiteKnight1)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 31

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 31 Then

                                Call WhiteKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteKnight1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 31 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveBlackPieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = WhiteKnight1.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteKnight1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub WhiteKnight2_Click(sender As Object, e As MouseEventArgs) Handles WhiteKnight2.Click

        If e.Button = MouseButtons.Left And WhiteKnight2.Size.Height = 100 Then

            If KingsExStatusWhite = True And Abs(WhiteKnight2.Location.X - 740) <> 460 Then

                Call KingsExchangeWhite(32, WhiteKnight2)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 32

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 32 Then

                                Call WhiteKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteKnight2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 32 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveBlackPieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = WhiteKnight2.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteKnight2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub WhiteKnight3_Click(sender As Object, e As MouseEventArgs) Handles WhiteKnight3.Click

        If e.Button = MouseButtons.Left And WhiteKnight3.Size.Height = 100 Then

            If KingsExStatusWhite = True And Abs(WhiteKnight3.Location.X - 740) <> 460 Then

                Call KingsExchangeWhite(33, WhiteKnight3)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 33

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 33 Then

                                Call WhiteKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteKnight3.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 33 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveBlackPieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = WhiteKnight3.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteKnight3)

                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackKnight1_Click(sender As Object, e As MouseEventArgs) Handles BlackKnight1.Click

        If e.Button = MouseButtons.Left And BlackKnight1.Size.Height = 100 Then

            If KingsExStatusBlack = True And Abs(BlackKnight1.Location.X - 740) <> 460 Then

                Call KingsExchangeBlack(-31, BlackKnight1)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -31

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -31 Then

                                Call BlackKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackKnight1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -31 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveWhitePieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = BlackKnight1.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackKnight1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackKnight2_Click(sender As Object, e As MouseEventArgs) Handles BlackKnight2.Click

        If e.Button = MouseButtons.Left And BlackKnight2.Size.Height = 100 Then

            If KingsExStatusBlack = True And Abs(BlackKnight2.Location.X - 740) <> 460 Then

                Call KingsExchangeBlack(-32, BlackKnight2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -32

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -32 Then

                                Call BlackKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackKnight2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -32 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveWhitePieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = BlackKnight2.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call BlackTurnSub()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackKnight2)
                                Call HideAllPossibleMoves()
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackKnight3_Click(sender As Object, e As MouseEventArgs) Handles BlackKnight3.Click

        If e.Button = MouseButtons.Left And BlackKnight3.Size.Height = 100 Then

            If KingsExStatusBlack = True And Abs(BlackKnight3.Location.X - 740) <> 460 Then

                Call KingsExchangeBlack(-33, BlackKnight3)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -33

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -33 Then

                                Call BlackKnightMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackKnight3.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -33 Then

                                If counter2 = 1 Or counter2 = 10 Then

                                    Board(counter1, counter2) = 0

                                    Call RemoveWhitePieceFromBoard(PieceToMove(SelectedPiece))

                                Else

                                    PieceToMove(SelectedPiece).location = BlackKnight3.Location

                                    Board(counter1, counter2) = SelectedPiece

                                End If

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackKnight3)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    'Bishops

    Private Sub WhiteBishop1_Click(sender As Object, e As MouseEventArgs) Handles WhiteBishop1.Click

        If e.Button = MouseButtons.Left And WhiteBishop1.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(41, WhiteBishop1)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 41

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 41 Then

                                Call WhiteBishopMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteBishop1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 41 Then

                                PieceToMove(SelectedPiece).location = WhiteBishop1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteBishop1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhiteBishop1.Size.Height = 100 Then

            If WhiteTurn = True Then

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = 41 Then

                            Call BishopsRageWhite(counter1, counter2)

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    Private Sub WhiteBishop2_Click(sender As Object, e As MouseEventArgs) Handles WhiteBishop2.Click

        If e.Button = MouseButtons.Left And WhiteBishop2.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(42, WhiteBishop2)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 42

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 42 Then

                                Call WhiteBishopMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf WhiteBishop2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 42 Then

                                PieceToMove(SelectedPiece).location = WhiteBishop2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteBishop2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And WhiteBishop2.Size.Height = 100 Then

            If WhiteTurn = True Then

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = 42 Then

                            Call BishopsRageWhite(counter1, counter2)

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    Private Sub BlackBishop1_Click(sender As Object, e As MouseEventArgs) Handles BlackBishop1.Click

        If e.Button = MouseButtons.Left And BlackBishop1.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-41, BlackBishop1)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -41

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -41 Then

                                Call BlackBishopMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackBishop1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -41 Then

                                PieceToMove(SelectedPiece).location = BlackBishop1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackBishop1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackBishop1.Size.Height = 100 Then

            If WhiteTurn = False Then

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = -41 Then

                            Call BishopsRageBlack(counter1, counter2)

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    Private Sub BlackBishop2_Click(sender As Object, e As MouseEventArgs) Handles BlackBishop2.Click

        If e.Button = MouseButtons.Left And BlackBishop2.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-42, BlackBishop2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -42

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -42 Then

                                Call BlackBishopMovement(counter1, counter2)

                            End If

                        Next

                    Next

                ElseIf BlackBishop2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -42 Then

                                PieceToMove(SelectedPiece).location = BlackBishop2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackBishop2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Button = MouseButtons.Right And BlackBishop2.Size.Height = 100 Then

            If WhiteTurn = False Then

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = -42 Then

                            Call BishopsRageBlack(counter1, counter2)

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    'Queens

    Private Sub WhiteQueen1_Click(sender As Object, e As MouseEventArgs) Handles WhiteQueen1.Click

        If e.Button = MouseButtons.Left And WhiteQueen1.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(51, WhiteQueen1)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    WhiteTurn = False

                    Call BlackBishop1_Click(sender, e)
                    Call BlackBishop2_Click(sender, e)

                    WhiteTurn = True

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 51

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 51 Then

                                If ParalysedWhiteQueen(1) = True Then

                                    Call WhiteKingMovement(counter1, counter2)

                                Else

                                    Call WhiteRookieMovement(counter1, counter2)
                                    Call WhiteBishopMovement(counter1, counter2)
                                    Call WhiteKnightMovement(counter1, counter2)

                                End If

                            End If

                        Next

                    Next

                ElseIf WhiteQueen1.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 51 Then

                                PieceToMove(SelectedPiece).location = WhiteQueen1.Location

                                Board(counter1, counter2) = SelectedPiece

                                WhiteQueen1Alive = False

                                If Form2.QueensAdCB.SelectedItem <> "1 Minute" Then

                                    Label12.Text = "00:" & Form2.QAT

                                Else

                                    Label12.Text = "01:00"

                                End If

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteQueen1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub WhiteQueen2_Click(sender As Object, e As MouseEventArgs) Handles WhiteQueen2.Click

        If e.Button = MouseButtons.Left And WhiteQueen2.Size.Height = 100 Then

            If KingsExStatusWhite = True Then

                Call KingsExchangeWhite(52, WhiteQueen2)

                MoveSound.Play()

            Else

                If WhiteTurn = True Then

                    WhiteTurn = False

                    Call BlackBishop1_Click(sender, e)
                    Call BlackBishop2_Click(sender, e)

                    WhiteTurn = True

                    Call DefaultCursorForBlack()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = 52

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 52 Then

                                If ParalysedWhiteQueen(2) = True Then

                                    Call WhiteKingMovement(counter1, counter2)

                                Else

                                    Call WhiteRookieMovement(counter1, counter2)
                                    Call WhiteBishopMovement(counter1, counter2)
                                    Call WhiteKnightMovement(counter1, counter2)

                                End If

                            End If

                        Next

                    Next

                ElseIf WhiteQueen2.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = 52 Then

                                PieceToMove(SelectedPiece).location = WhiteQueen2.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call WhiteTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForWhite()
                                Call DefaultCursorForBlack()
                                Call HandCursorForWhite()
                                Call RemoveWhitePieceFromBoard(WhiteQueen2)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackQueen1_Click(sender As Object, e As MouseEventArgs) Handles BlackQueen1.Click

        If e.Button = MouseButtons.Left And BlackQueen1.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-51, BlackQueen1)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    WhiteTurn = True

                    Call WhiteBishop1_Click(sender, e)
                    Call WhiteBishop2_Click(sender, e)

                    WhiteTurn = False

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -51

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -51 Then

                                If ParalysedBlackQueen(1) = True Then

                                    Call BlackKingMovement(counter1, counter2)

                                Else

                                    Call BlackRookieMovement(counter1, counter2)
                                    Call BlackBishopMovement(counter1, counter2)
                                    Call BlackKnightMovement(counter1, counter2)

                                End If

                            End If

                        Next

                    Next

                ElseIf BlackQueen1.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -51 Then

                                PieceToMove(SelectedPiece).Location = BlackQueen1.Location

                                Board(counter1, counter2) = SelectedPiece

                                BlackQueen1Alive = False

                                If Form2.QueensAdCB.SelectedItem <> "1 Minute" Then

                                    Label10.Text = "00:" & Form2.QAT

                                Else

                                    Label10.Text = "01:00"

                                End If

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackQueen1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    Private Sub BlackQueen2_Click(sender As Object, e As MouseEventArgs) Handles BlackQueen2.Click

        If e.Button = MouseButtons.Left And BlackQueen2.Size.Height = 100 Then

            If KingsExStatusBlack = True Then

                Call KingsExchangeBlack(-52, BlackQueen2)

                MoveSound.Play()

            Else

                If WhiteTurn = False Then

                    WhiteTurn = True

                    Call WhiteBishop1_Click(sender, e)
                    Call WhiteBishop2_Click(sender, e)

                    WhiteTurn = False

                    Call DefaultCursorForWhite()
                    Call HideAllPossibleMoves()
                    Call InitialImageForBlack()
                    Call InitialImageForWhite()

                    SelectedPiece = -52

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -52 Then

                                If ParalysedBlackQueen(2) = True Then

                                    Call BlackKingMovement(counter1, counter2)

                                Else

                                    Call BlackRookieMovement(counter1, counter2)
                                    Call BlackBishopMovement(counter1, counter2)
                                    Call BlackKnightMovement(counter1, counter2)

                                End If

                            End If

                        Next

                    Next

                ElseIf BlackQueen2.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                    Call InitialImageForBlack()
                    Call InitialImageForWhite()
                    Call ClearInitialLocation()

                    For counter1 = 1 To 8

                        For counter2 = 1 To 10

                            If Board(counter1, counter2) = -52 Then

                                PieceToMove(SelectedPiece).Location = BlackQueen1.Location

                                Board(counter1, counter2) = SelectedPiece

                                Call BlackTurnSub()
                                Call HideAllPossibleMoves()
                                Call DefaultCursorForBlack()
                                Call DefaultCursorForWhite()
                                Call HandCursorForBlack()
                                Call RemoveBlackPieceFromBoard(BlackQueen1)
                                Call MainEntranceOnDeath(counter1, counter2)

                            End If

                        Next

                    Next

                End If

            End If

        End If

    End Sub

    'Kings

    Private Sub WhiteKing_Click(sender As Object, e As MouseEventArgs) Handles WhiteKing.Click

        If e.Button = MouseButtons.Left Then

            If WhiteTurn = True Then

                Call DefaultCursorForBlack()
                Call HideAllPossibleMoves()
                Call InitialImageForBlack()
                Call InitialImageForWhite()

                SelectedPiece = 60

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = 60 Then

                            Call WhiteKingMovement(counter1, counter2)

                            If ShortCastleWhite = True And Board(8, 7) = 0 And Board(8, 8) = 0 Then

                                PossibleMove_88.Visible = True

                            End If

                            If LongCastleWhite = True And Board(8, 5) = 0 And Board(8, 3) = 0 And Board(8, 4) = 0 Then

                                PossibleMove_48.Visible = True

                            End If

                        End If

                    Next

                Next

            ElseIf WhiteKing.Cursor = Cursors.Hand And SelectedPiece < 0 Then

                Call InitialImageForBlack()
                Call InitialImageForWhite()
                Call ClearInitialLocation()

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = 60 Then

                            PieceToMove(SelectedPiece).location = WhiteKing.Location

                            Board(counter1, counter2) = SelectedPiece

                            Call WhiteTurnSub()
                            Call HideAllPossibleMoves()
                            Call DefaultCursorForWhite()
                            Call DefaultCursorForBlack()
                            Call HandCursorForWhite()
                            Call RemoveWhitePieceFromBoard(WhiteKing)

                            Timer1.Stop()
                            Timer2.Stop()
                            QATWhite.Stop()
                            QATBlack.Stop()

                            GameEndsSound.Play()

                            MsgBox("Black Wins By Checkmate!", , "Black Won!")

                            Me.Close()

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    Private Sub BlackKing_Click(sender As Object, e As MouseEventArgs) Handles BlackKing.Click

        If e.Button = MouseButtons.Left And KingsExStatusBlack = False Then

            If WhiteTurn = False Then

                Call DefaultCursorForWhite()
                Call HideAllPossibleMoves()
                Call InitialImageForBlack()
                Call InitialImageForWhite()

                SelectedPiece = -60

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = -60 Then

                            Call BlackKingMovement(counter1, counter2)

                            If ShortCastleBlack = True And Board(1, 7) = 0 And Board(1, 8) = 0 Then

                                PossibleMove_81.Visible = True

                            End If

                            If LongCastleBlack = True And Board(1, 5) = 0 And Board(1, 3) = 0 And Board(1, 4) = 0 Then

                                PossibleMove_41.Visible = True

                            End If

                        End If

                    Next

                Next

            ElseIf BlackKing.Cursor = Cursors.Hand And SelectedPiece > 0 Then

                Call InitialImageForBlack()
                Call InitialImageForWhite()
                Call ClearInitialLocation()

                For counter1 = 1 To 8

                    For counter2 = 1 To 10

                        If Board(counter1, counter2) = -60 Then

                            PieceToMove(SelectedPiece).location = BlackKing.Location

                            Board(counter1, counter2) = SelectedPiece

                            Call BlackTurnSub()
                            Call HideAllPossibleMoves()
                            Call DefaultCursorForWhite()
                            Call DefaultCursorForBlack()
                            Call HandCursorForBlack()
                            Call RemoveBlackPieceFromBoard(BlackKing)

                            Timer1.Stop()
                            Timer2.Stop()
                            QATWhite.Stop()
                            QATBlack.Stop()

                            GameEndsSound.Play()

                            MsgBox("White Wins By Checkmate!", , "White Won!")

                            Me.Close()

                        End If

                    Next

                Next

            End If

        End If

    End Sub

    'Possible Moves

    Private Sub PossibleMove_11_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_11.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_11.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_12_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_12.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_12.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_13_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_13.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_13.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_14_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_14.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_14.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_15_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_15.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(5, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_15.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_16_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_16.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_16.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_17_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_17.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_17.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_18_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_18.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 1) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_18.Location)

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_21_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_21.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            MoveSound.Play()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_21.Location)

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_22_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_22.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_22.Location)

                        Call MainEntranceClmn2(True, 2)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_23_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_23.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_23.Location)

                        Call MainEntranceClmn2(True, 3)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_24_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_24.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_24.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceClmn2(True, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_25_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_25.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call EnPassantWhite(counter1, counter2)

                        Board(counter1, counter2) = 0
                        Board(5, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_25.Location)

                        Call MainEntranceClmn2(True, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_26_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_26.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_26.Location)

                        Call MainEntranceClmn2(True, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_27_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_27.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_27.Location)

                        Call MainEntranceClmn2(True, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_28_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_28.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 2) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_28.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_31_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_31.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_31.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_32_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_32.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_32.Location)

                        Call MainEntranceClmn3(True, 2)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_33_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_33.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_33.Location)

                        Call MainEntranceClmn3(True, 3)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_34_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_34.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_34.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceClmn3(True, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_35_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_35.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call EnPassantWhite(counter1, counter2)

                        Board(counter1, counter2) = 0
                        Board(5, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_35.Location)

                        Call MainEntranceClmn3(True, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_36_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_36.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_36.Location)

                        Call MainEntranceClmn3(True, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_37_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_37.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_37.Location)

                        Call MainEntranceClmn3(True, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_38_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_38.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 3) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_38.Location)

                        Call KnightsHoodOff()

                        MoveSound.Play()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_41_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_41.Click

        If e.Button = MouseButtons.Left Then

            If Floor(Abs(SelectedPiece / 10)) = 1 Then

                SeventyFiveMoveRule = 75

            End If

            Select Case SelectedPiece

                Case 21

                    LongCastleWhite = False

                Case 22

                    ShortCastleWhite = False

                Case -21

                    LongCastleBlack = False

                Case -22

                    ShortCastleBlack = False

            End Select

            Call HideAllPossibleMoves()
            Call InitialImageForBlack()
            Call InitialImageForWhite()

            If WhiteTurn = True Then

                Call BlackTurnSub()
                Call DefaultCursorForWhite()
                Call ResetTakeBlackKnightElig()
                Call HandCursorForBlack()

            Else

                Call WhiteTurnSub()
                Call DefaultCursorForBlack()
                Call ResetTakeWhiteKnightElig()
                Call HandCursorForWhite()

            End If

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If SelectedPiece = -60 And LongCastleBlack = True Then

                            Board(1, 5) = -21
                            Board(1, 2) = 0
                            BlackRook1.Location = New Point(690, 20)
                            LongCastleBlack = False

                            CastleSound.Play()

                        Else

                            MoveSound.Play()

                        End If

                        Board(counter1, counter2) = 0
                        Board(1, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_41.Location)

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_42_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_42.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_42.Location)

                        Call MainEntranceMidClmns(True, 2, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_43_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_43.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_43.Location)

                        Call MainEntranceMidClmns(True, 3, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_44_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_44.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_44.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceMidClmns(True, 4, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_45_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_45.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_45.Location)

                        Call MainEntranceMidClmns(True, 5, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_46_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_46.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_46.Location)

                        Call MainEntranceMidClmns(True, 6, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_47_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_47.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_47.Location)

                        Call MainEntranceMidClmns(True, 7, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_48_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_48.Click

        If e.Button = MouseButtons.Left Then

            If Floor(Abs(SelectedPiece / 10)) = 1 Then

                SeventyFiveMoveRule = 75

            End If

            Select Case SelectedPiece

                Case 21

                    LongCastleWhite = False

                Case 22

                    ShortCastleWhite = False

                Case -21

                    LongCastleBlack = False

                Case -22

                    ShortCastleBlack = False

            End Select

            Call HideAllPossibleMoves()
            Call InitialImageForBlack()
            Call InitialImageForWhite()

            If WhiteTurn = True Then

                Call BlackTurnSub()
                Call DefaultCursorForWhite()
                Call ResetTakeBlackKnightElig()
                Call HandCursorForBlack()

            Else

                Call WhiteTurnSub()
                Call DefaultCursorForBlack()
                Call ResetTakeWhiteKnightElig()
                Call HandCursorForWhite()

            End If

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If SelectedPiece = 60 And LongCastleWhite = True Then

                            Board(8, 5) = 21
                            Board(8, 2) = 0
                            WhiteRook1.Location = New Point(690, 720)
                            LongCastleWhite = False

                            CastleSound.Play()

                        Else

                            MoveSound.Play()

                        End If

                        Board(counter1, counter2) = 0
                        Board(8, 4) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_48.Location)

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_51_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_51.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_51.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_52_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_52.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_52.Location)

                        Call MainEntranceMidClmns(True, 2, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_53_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_53.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_53.Location)

                        Call MainEntranceMidClmns(True, 3, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_54_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_54.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_54.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceMidClmns(True, 4, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_55_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_55.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_55.Location)

                        Call MainEntranceMidClmns(True, 5, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_56_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_56.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_56.Location)

                        Call MainEntranceMidClmns(True, 6, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_57_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_57.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_57.Location)

                        Call MainEntranceMidClmns(True, 7, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_58_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_58.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 5) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_58.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_61_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_61.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_61.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_62_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_62.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_62.Location)

                        Call MainEntranceMidClmns(True, 2, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_63_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_63.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_63.Location)

                        Call MainEntranceMidClmns(True, 3, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_64_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_64.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_64.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceMidClmns(True, 4, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_65_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_65.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_65.Location)

                        Call MainEntranceMidClmns(True, 5, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_66_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_66.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_66.Location)

                        Call MainEntranceMidClmns(True, 6, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_67_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_67.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_67.Location)

                        Call MainEntranceMidClmns(True, 7, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_68_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_68.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 6) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_68.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_71_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_71.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_71.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_72_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_72.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_72.Location)

                        Call MainEntranceMidClmns(True, 2, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_73_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_73.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_73.Location)

                        Call MainEntranceMidClmns(True, 3, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_74_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_74.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_74.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceMidClmns(True, 4, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_75_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_75.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_75.Location)

                        Call MainEntranceMidClmns(True, 5, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_76_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_76.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_76.Location)

                        Call MainEntranceMidClmns(True, 6, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_77_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_77.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_77.Location)

                        Call MainEntranceMidClmns(True, 7, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_78_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_78.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 7) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_78.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_81_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_81.Click

        If e.Button = MouseButtons.Left Then

            If Floor(Abs(SelectedPiece / 10)) = 1 Then

                SeventyFiveMoveRule = 75

            End If

            Select Case SelectedPiece

                Case 21

                    LongCastleWhite = False

                Case 22

                    ShortCastleWhite = False

                Case -21

                    LongCastleBlack = False

                Case -22

                    ShortCastleBlack = False

            End Select

            Call HideAllPossibleMoves()
            Call InitialImageForBlack()
            Call InitialImageForWhite()

            If WhiteTurn = True Then

                Call BlackTurnSub()
                Call DefaultCursorForWhite()
                Call ResetTakeBlackKnightElig()
                Call HandCursorForBlack()

            Else

                Call WhiteTurnSub()
                Call DefaultCursorForBlack()
                Call ResetTakeWhiteKnightElig()
                Call HandCursorForWhite()

            End If

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If SelectedPiece = -60 And ShortCastleBlack = True Then

                            Board(1, 7) = -22
                            Board(1, 9) = 0
                            BlackRook2.Location = New Point(890, 20)
                            ShortCastleBlack = False

                            CastleSound.Play()

                        Else

                            MoveSound.Play()

                        End If

                        Board(counter1, counter2) = 0
                        Board(1, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_81.Location)

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_82_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_82.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_82.Location)

                        Call MainEntranceClmn8(True, 2)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_83_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_83.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_83.Location)

                        Call MainEntranceClmn8(True, 3)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_84_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_84.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_84.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceClmn8(True, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_85_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_85.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_85.Location)

                        Call MainEntranceClmn8(True, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_86_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_86.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_86.Location)

                        Call MainEntranceClmn8(True, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_87_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_87.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_87.Location)

                        Call MainEntranceClmn8(True, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_88_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_88.Click

        If e.Button = MouseButtons.Left Then

            If Floor(Abs(SelectedPiece / 10)) = 1 Then

                SeventyFiveMoveRule = 75

            End If

            Select Case SelectedPiece

                Case 21

                    LongCastleWhite = False

                Case 22

                    ShortCastleWhite = False

                Case -21

                    LongCastleBlack = False

                Case -22

                    ShortCastleBlack = False

            End Select

            Call HideAllPossibleMoves()
            Call InitialImageForBlack()
            Call InitialImageForWhite()

            If WhiteTurn = True Then

                Call BlackTurnSub()
                Call DefaultCursorForWhite()
                Call ResetTakeBlackKnightElig()
                Call HandCursorForBlack()

            Else

                Call WhiteTurnSub()
                Call DefaultCursorForBlack()
                Call ResetTakeWhiteKnightElig()
                Call HandCursorForWhite()

            End If

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If SelectedPiece = 60 And ShortCastleWhite = True Then

                            Board(8, 7) = 22
                            Board(8, 9) = 0
                            WhiteRook2.Location = New Point(890, 720)
                            ShortCastleWhite = False

                            CastleSound.Play()

                        Else

                            MoveSound.Play()

                        End If

                        Board(counter1, counter2) = 0
                        Board(8, 8) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_88.Location)

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_91_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_91.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        MoveSound.Play()

                        Board(counter1, counter2) = 0
                        Board(1, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_91.Location)

                        Call KnightsHoodOff()

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_92_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_92.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_92.Location)

                        Call MainEntranceClmn9(True, 2)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_93_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_93.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_93.Location)

                        Call MainEntranceClmn9(True, 3)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_94_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_94.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_94.Location)

                        Call EnPassantBlack(counter1, counter2)
                        Call MainEntranceClmn9(True, 4)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_95_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_95.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        If counter1 = 7 Then

                            Call EnPassantWhite(counter1, counter2)

                        End If

                        Board(counter1, counter2) = 0
                        Board(5, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_95.Location)

                        Call MainEntranceClmn9(True, 5)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_96_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_96.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_96.Location)

                        Call MainEntranceClmn9(True, 6)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_97_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_97.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_97.Location)

                        Call MainEntranceClmn9(True, 7)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_98_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_98.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 9) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_98.Location)

                        MoveSound.Play()

                        Call KnightsHoodOff()

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_101_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_101.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(1, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_101.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_102_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_102.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(2, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_102.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_103_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_103.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(3, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_103.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_104_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_104.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(4, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_104.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_105_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_105.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(5, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_105.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_106_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_106.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(6, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_106.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_107_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_107.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(7, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_107.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub PossibleMove_108_Click(sender As Object, e As MouseEventArgs) Handles PossibleMove_108.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Board(counter1, counter2) = 0
                        Board(8, 10) = SelectedPiece
                        PieceToMove(SelectedPiece).location = New Point(PossibleMove_108.Location)

                        MoveSound.Play()

                        Call KnightsHoodOn(SelectedPiece)

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    'Player Timers

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Me.WindowState = FormWindowState.Minimized Then

            Timer1.Stop()
            QATBlack.Stop()

        End If

        If Form2.PlayerTimerCB.SelectedItem <> "No Time" Then

            If WhiteS = 0 Then

                If WhiteM = 0 Then

                    Timer1.Stop()
                    Timer2.Stop()
                    QATBlack.Stop()
                    QATWhite.Stop()
                    Timer3.Stop()
                    Timer4.Stop()

                    GameEndsSound.Play()

                    MsgBox("White loses to time!", , "White Won!")

                    Close()

                End If

                WhiteM -= 1
                WhiteS = 59

            Else

                WhiteS -= 1

            End If

            If WhiteM <= 9 Then

                If WhiteS <= 9 Then

                    Label8.Text = "0" & WhiteM & ":0" & WhiteS

                ElseIf WhiteS > 9 Then

                    Label8.Text = "0" & WhiteM & ":" & WhiteS

                End If

            ElseIf WhiteM > 9 Then

                If WhiteS <= 9 Then

                    Label8.Text = WhiteM & ":0" & WhiteS

                ElseIf WhiteS > 9 Then

                    Label8.Text = WhiteM & ":" & WhiteS

                End If

            End If

        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Me.WindowState = FormWindowState.Minimized Then

            Timer2.Stop()
            QATWhite.Stop()

        End If

        If Form2.PlayerTimerCB.SelectedItem <> "No Time" Then

            If BlackS = 0 Then

                If BlackM = 0 Then

                    Timer1.Stop()
                    Timer2.Stop()
                    QATBlack.Stop()
                    QATWhite.Stop()
                    Timer3.Stop()
                    Timer4.Stop()

                    GameEndsSound.Play()

                    MsgBox("Black loses to time!", , "White Won!")

                    Close()

                End If

                BlackM -= 1
                BlackS = 59

            Else

                BlackS -= 1

            End If

            If BlackM <= 9 Then

                If BlackS <= 9 Then

                    Label14.Text = "0" & BlackM & ":0" & BlackS

                ElseIf BlackS > 9 Then

                    Label14.Text = "0" & BlackM & ":" & BlackS

                End If

            ElseIf BlackM > 9 Then

                If BlackS <= 9 Then

                    Label14.Text = BlackM & ":0" & BlackS

                ElseIf BlackS > 9 Then

                    Label14.Text = BlackM & ":" & BlackS

                End If

            End If

        End If

    End Sub

    'Queen's Advantage Timers

    Private Sub QATWhite_Tick(sender As Object, e As EventArgs) Handles QATWhite.Tick

        If Me.WindowState = FormWindowState.Minimized Then

            QATWhite.Stop()

        End If

        WhiteQATTC -= 1

        If WhiteQATTC > 9 Then

            Label12.Text = "00:" & WhiteQATTC

        ElseIf WhiteQATTC <= 9 And WhiteQATTC > 0 Then

            Label12.Text = "00:0" & WhiteQATTC

        ElseIf WhiteQATTC = 0 Then

            Label12.Text = "- - : - -"

            WhiteQATTC = Form2.QAT

            QATWhite.Stop()

            Call WhiteQueensAdv()

        End If

    End Sub

    Private Sub QATBlack_Tick(sender As Object, e As EventArgs) Handles QATBlack.Tick

        If Me.WindowState = FormWindowState.Minimized Then

            QATBlack.Stop()

        End If

        BlackQATTC -= 1

        If BlackQATTC > 9 Then

            Label10.Text = "00:" & BlackQATTC

        ElseIf BlackQATTC <= 9 And BlackQATTC > 0 Then

            Label10.Text = "00:0" & BlackQATTC

        ElseIf BlackQATTC = 0 Then

            Label10.Text = "- - : - -"

            BlackQATTC = Form2.QAT

            QATBlack.Stop()

            Call BlackQueensAdv()

        End If

    End Sub

    'Cycling the Possible Spawnpoints of the Queen 

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        QueensAdCycleSound.Play()

        If Temp3 = 0 Then

            WhiteQueen1.Size = New Size(100, 100)

            WhitePiecesTaken -= 1

        End If

        WhiteQueen1.Location = New Point((QueensAdvClmns(Temp1) + 1.9) * 100, (QueensAdvRow - 0.8) * 100)

        If Temp1 = Temp2 Then

            Temp1 = 1

        Else

            Temp1 += 1

        End If

        Temp3 += 1

        If Temp3 = RandomNumber Then

            Board(WhiteQueen1.Location.Y / 100 + 0.8, WhiteQueen1.Location.X / 100 - 1.9) = 51

            WhiteQueen1Alive = True

            Temp1 = 0
            Temp2 = 0
            Temp3 = 0
            QueensAdvRow = 0

            For counter = 1 To 8

                QueensAdvClmns(counter) = 0

            Next

            Timer3.Stop()

        End If

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        QueensAdCycleSound.Play()

        If Temp3 = 0 Then

            BlackQueen1.Size = New Size(100, 100)

            BlackPiecesTaken -= 1

        End If

        BlackQueen1.Location = New Point((QueensAdvClmns(Temp1) + 1.9) * 100, (QueensAdvRow - 0.8) * 100)

        If Temp1 = Temp2 Then

            Temp1 = 1

        Else

            Temp1 += 1

        End If

        Temp3 += 1

        If Temp3 = RandomNumber Then

            Board(BlackQueen1.Location.Y / 100 + 0.8, BlackQueen1.Location.X / 100 - 1.9) = -51

            BlackQueen1Alive = True

            Temp1 = 0
            Temp2 = 0
            Temp3 = 0
            QueensAdvRow = 0

            For counter = 1 To 8

                QueensAdvClmns(counter) = 0

            Next

            Timer4.Stop()

        End If

    End Sub

    'King's Exchange Buttons

    Private Sub KingsExBlack_Click(sender As Object, e As EventArgs) Handles KingsExBlack.Click

        Call InitialImageForBlack()
        Call InitialImageForWhite()
        Call HideAllPossibleMoves()

        KingsExBlack.Visible = False
        CancelBlackKingEx.Visible = True

        KingsExStatusBlack = True

        Call KingsExAvailPiecesBlack()

    End Sub

    Private Sub KingsExWhite_Click(sender As Object, e As EventArgs) Handles KingsExWhite.Click

        Call InitialImageForBlack()
        Call InitialImageForWhite()
        Call HideAllPossibleMoves()

        KingsExWhite.Visible = False
        CancelWhiteKingEx.Visible = True

        KingsExStatusWhite = True

        Call KingsExAvailPiecesWhite()

    End Sub

    Private Sub CancelBlackKingEx_Click(sender As Object, e As EventArgs) Handles CancelBlackKingEx.Click

        KingsExStatusBlack = False
        Call InitialImageForBlack()
        CancelBlackKingEx.Visible = False
        KingsExBlack.Visible = True

    End Sub

    Private Sub CancelWhiteKingEx_Click(sender As Object, e As EventArgs) Handles CancelWhiteKingEx.Click

        KingsExStatusWhite = False
        Call InitialImageForWhite()
        CancelWhiteKingEx.Visible = False
        KingsExWhite.Visible = True

    End Sub

    'En Passants

    Private Sub EnPassant1_Click(sender As Object, e As MouseEventArgs) Handles EnPassant1.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 2)))

                        Board(counter1, counter2) = 0
                        Board(3, 2) = SelectedPiece
                        Board(4, 2) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant1.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant2_Click(sender As Object, e As MouseEventArgs) Handles EnPassant2.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 3)))

                        Board(counter1, counter2) = 0
                        Board(3, 3) = SelectedPiece
                        Board(4, 3) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant2.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant3_Click(sender As Object, e As MouseEventArgs) Handles EnPassant3.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 4)))

                        Board(counter1, counter2) = 0
                        Board(3, 4) = SelectedPiece
                        Board(4, 4) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant3.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant4_Click(sender As Object, e As MouseEventArgs) Handles EnPassant4.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 5)))

                        Board(counter1, counter2) = 0
                        Board(3, 5) = SelectedPiece
                        Board(4, 5) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant4.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant5_Click(sender As Object, e As MouseEventArgs) Handles EnPassant5.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 6)))

                        Board(counter1, counter2) = 0
                        Board(3, 6) = SelectedPiece
                        Board(4, 6) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant5.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant6_Click(sender As Object, e As MouseEventArgs) Handles EnPassant6.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 7)))

                        Board(counter1, counter2) = 0
                        Board(3, 7) = SelectedPiece
                        Board(4, 7) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant6.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant7_Click(sender As Object, e As MouseEventArgs) Handles EnPassant7.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 8)))

                        Board(counter1, counter2) = 0
                        Board(3, 8) = SelectedPiece
                        Board(4, 8) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant7.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant8_Click(sender As Object, e As MouseEventArgs) Handles EnPassant8.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveBlackPieceFromBoard(PieceToMove(Board(4, 9)))

                        Board(counter1, counter2) = 0
                        Board(3, 9) = SelectedPiece
                        Board(4, 9) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant8.Location

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant9_Click(sender As Object, e As MouseEventArgs) Handles EnPassant9.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 2)))

                        Board(counter1, counter2) = 0
                        Board(6, 2) = SelectedPiece
                        Board(5, 2) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant9.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant10_Click(sender As Object, e As MouseEventArgs) Handles EnPassant10.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 3)))

                        Board(counter1, counter2) = 0
                        Board(6, 3) = SelectedPiece
                        Board(5, 3) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant10.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant11_Click(sender As Object, e As MouseEventArgs) Handles EnPassant11.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 4)))

                        Board(counter1, counter2) = 0
                        Board(6, 4) = SelectedPiece
                        Board(5, 4) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant11.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant12_Click(sender As Object, e As MouseEventArgs) Handles EnPassant12.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 5)))

                        Board(counter1, counter2) = 0
                        Board(6, 5) = SelectedPiece
                        Board(5, 5) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant12.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant13_Click(sender As Object, e As MouseEventArgs) Handles EnPassant13.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 6)))

                        Board(counter1, counter2) = 0
                        Board(6, 6) = SelectedPiece
                        Board(5, 6) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant13.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant14_Click(sender As Object, e As MouseEventArgs) Handles EnPassant14.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 7)))

                        Board(counter1, counter2) = 0
                        Board(6, 7) = SelectedPiece
                        Board(5, 7) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant14.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant15_Click(sender As Object, e As MouseEventArgs) Handles EnPassant15.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 8)))

                        Board(counter1, counter2) = 0
                        Board(6, 8) = SelectedPiece
                        Board(5, 8) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant15.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

    Private Sub EnPassant16_Click(sender As Object, e As MouseEventArgs) Handles EnPassant16.Click

        If e.Button = MouseButtons.Left Then

            Call PossibleMoveProcedure1()

            For counter1 = 1 To 8

                For counter2 = 1 To 10

                    If Board(counter1, counter2) = SelectedPiece Then

                        Call RemoveWhitePieceFromBoard(PieceToMove(Board(5, 9)))

                        Board(counter1, counter2) = 0
                        Board(6, 9) = SelectedPiece
                        Board(5, 9) = 0

                        TakeSound.Play()

                        PieceToMove(SelectedPiece).Location = EnPassant16.Location

                        Exit Sub

                    End If

                Next

            Next

        End If

    End Sub

End Class