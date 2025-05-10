VAR PelayanDialogue = 1
VAR MiniGames1 = false
VAR ChapterStory1 = 1
VAR TakingBook = false

=== StartChapter1 ===
#Hadi
Meskipun sudah sering cukup ke sini
#Hadi
Setiap kali datang aku selalu merasa iri
#endinteract
->END

=== Pelayan1 ===
{PelayanDialogue == 1: ->PelayanDialogue1}
{PelayanDialogue == 2: ->PelayanDialogue2}
{PelayanDialogue == 3: ->PelayanDialogue3}
{PelayanDialogue > 3: ->PelayanDialogue4}

= PelayanDialogue1
#Pelayan1
Halo Hadi
#Hadi
Halo juga
#Pelayan1
Hari ini kamu datang juga ya
#endinteract
~ PelayanDialogue = PelayanDialogue + 1
-> END

= PelayanDialogue2
#Pelayan1
Cuaca hari akhir akhir ini sangat panas
#Hadi
Katanya musim kemarau sudah mau dekat
#Pelayan1
Iya, jangan lupa untuk membawa minum
#endinteract
~ PelayanDialogue = PelayanDialogue + 1
-> END

= PelayanDialogue3
#Pelayan1
Ku dengar sekarang banyak orang terkena penyakit
#Pelayan1
sebaiknya kamu juga hati hati
#endinteract
~ PelayanDialogue = PelayanDialogue + 1
-> END

= PelayanDialogue4
#Pelayan1
Selamat bersenang-senang
#endinteract
->END

=== StoryChapter1 ===
{ChapterStory1 == 1:->Story1Chapter1}
{ChapterStory1 == 2:->Story2Chapter1}

=Story1Chapter1
{MiniGames1: ->AfterMiniGame}
#Hadi
...
#Camera1

#Hadi
Hei, azmi!

#Azmi #fade
Oh

#Azmi
ternyata kamu Hadi.

#Hadi
Aku baru mendengar kabar bahwa kamu telah kembali

#Hadi
jadi aku berlari ke rumah mu

#Azmi
Padahal rumah mu cukup jauh 

#Azmi
Kamu bisa besok lagi karena sekarang sudah sore

#Hadi 
Mau bagaimana lagi

#Hadi
Sebagai seorang teman sudah pasti senang melihat temannya keluar dari rumah sakit

#Azmi #smile
Terima kasih sudah peduli dengan ku

#Hadi
...

#Azmi
Hei, tak usah khawatir

#Hadi
Apa kamu beneran baik-baik saja?

#Azmi
Iya, aku baik baik saja

#Azmi
Jadi sebaiknya kamu tidak perlu khawatir

#Hadi
baiklah

#Azmi #think
kalau begitu akan ku tunjukkan

#Hadi #question 
Apa maksud mu?

#Azmi
Maksud ku bahwa aku ini masih baik-baik saja 
#Azmi
Mari kita coba bermain permainan
#Azmi
bagaimana?

#Hadi
Boleh, permainan seperti apa?

#Hadi #think
baiklah

#Azmi
Biar makin seru

#Azmi
bagaimana jika yang kalah mematuhi perintah yang menang

#Hadi
Ku kira hanya permainan biasa saja

#Azmi
Jika biasa saja mana mungkin seru kan

#Hadi
Iya sih

#Azmi
Bagaimana?

#Azmi
Apa kamu setuju

#Hadi
Aku setuju

#minigames
->END
=Story2Chapter1
{!TakingBook: -> AskBook}
HEI
->END
=AfterMiniGame
#Hadi
Tidak ku sangka aku akan kalah

#Azmi
Kamu ingatkan

#Azmi
yang kalah harus menuruti permintaan yang menang

#Hadi
Iya aku ingat

#Haid
Jadi apa yang kamu inginkan?

#Azmi
Tenang

#Azmi 
aku tidak akan membuat permintaan yang aneh aneh,

#Azmi
Bisakah kamu ambilkan aku buku yang ada di meja makan?

#Hadi
Itu saja?

#Hadi
Apakah kamu tidak menginginkan hal lain?

#Azmi
Itu saja sudah cukup

#Azmi
tadi aku sudah bilang tidak akan membuat permintaan yang aneh aneh

~ChapterStory1 = ChapterStory1 + 1
->END
->END
=AskBook
#Azmi
Kenapa?
#Hadi
Bukunya ada di mana ya?
#Azmi
Ada di meja makan
#Azmi
Kamu tinggal masuk saja ke rumah lewat pintu belakang
->END