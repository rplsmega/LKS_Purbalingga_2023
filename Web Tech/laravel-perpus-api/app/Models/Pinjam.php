<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Pinjam extends Model
{
    use HasFactory;
    protected $guarded = ['id'];

    public function peminjam()
    {
        return $this->belongsTo(Peminjam::class);
    }

    public function buku()
    {
        return $this->belongsTo(Buku::class);
    }
}
