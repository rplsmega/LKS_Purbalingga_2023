<?php

namespace App\Http\Controllers;

use App\Models\Pinjam;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Validator;

class PinjamController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $pinjam = Pinjam::with('peminjam', 'buku')->get();

        return response()->json(compact('pinjam'), 200);
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        // 
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $validator = Validator::make($request->all(), [
            'peminjam_id' => 'required',
            'buku_id' => 'required',
            'tgl_pinjam' => 'required',
            'tgl_kembali' => 'required',
        ]);

        if($validator->fails()) {
            return response()->json([
                'errors' => $validator->errors
            ], 400);
        }

        $pinjam = Pinjam::create([
            'peminjam_id' => $request->peminjam_id,
            'buku_id' => $request->buku_id,
            'tgl_pinjam' => $request->tgl_pinjam,
            'tgl_kembali' => $request->tgl_kembali,
        ]);

        return response()->json([
            'message' => 'Berhasil meminjam buku'
        ], 200);
    }

    /**
     * Display the specified resource.
     */
    public function show(Pinjam $pinjam)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Pinjam $pinjam)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Pinjam $pinjam)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Pinjam $pinjam)
    {
        if($pinjam) {
            $pinjam->delete();

            return response()->json([
                'message' => 'Berhasil mengembalikan buku'
            ], 200);
        }

        return response()->json([
            'message' => 'Buku Not Found'
        ], 404);
    }
}
