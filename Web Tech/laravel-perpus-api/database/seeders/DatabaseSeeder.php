<?php

namespace Database\Seeders;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use App\Models\Buku;
use App\Models\Peminjam;
use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\Hash;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        Peminjam::create([
            'name' => 'Budi',
            'email' => 'budi@gmail.com',
            'pt_profile' => null,
            'pt_cover' => null,
            'biodata' => 'Pelajar yg sudah mau lulus',
            'password' => Hash::make('12345678'),
        ]);
        Peminjam::create([
            'name' => 'Susi',
            'email' => 'susi@gmail.com',
            'pt_profile' => null,
            'pt_cover' => null,
            'biodata' => 'Ibu rumah tangga',
            'password' => Hash::make('12345678'),
        ]);
        Peminjam::create([
            'name' => 'Balmond',
            'email' => 'balmond@gmail.com',
            'pt_profile' => null,
            'pt_cover' => null,
            'biodata' => 'Pemain basket yg suka baca buku',
            'password' => Hash::make('12345678'),
        ]);

        Buku::create([
            'title' => 'Buku Olah Raga',
            'cover' => null,
            'stock' => 4
        ]);
        Buku::create([
            'title' => 'Kumpulan Resep Masakkan Lebaran',
            'cover' => null,
            'stock' => 2
        ]);
        Buku::create([
            'title' => 'Naruto',
            'cover' => null,
            'stock' => 8
        ]);
    }
}
