<script setup>
import { ref } from 'vue';
import AppLayout from '../components/AppLayout.vue';

let pinjams = ref('')

fetch(`http://localhost:8000/api/pinjam`, {
    method: 'GET',
    headers: {'Content-Type': 'application/json'}
}).then(res => res.json()).then(res => {
    pinjams.value = res.pinjam
}).catch(err => console.log(err))
</script>

<template>
    <AppLayout>
        <div class="container m-auto">
            <table v-if="pinjams" class="w-[80%] mt-4">
                <tr class="bg-slate-900">
                    <th class="text-white">ID</th>
                    <th class="text-white">Nama</th>
                    <th class="text-white">Judul Buku</th>
                    <th class="text-white">Tgl Pinjam</th>
                    <th class="text-white">Tgl Kembali</th>
                </tr>
                <tr v-for="(pinjam, index) in pinjams" :key="index">
                    <td>{{ pinjam.id }}</td>
                    <td>{{ pinjam.peminjam_id }}</td>
                    <td>{{ pinjam.buku_id }}</td>
                    <td>{{ pinjam.tgl_pinjam }}</td>
                    <td>{{ pinjam.tgl_kembali }}</td>
                </tr>
            </table>
            <div v-else>
                <h1>Tidak ada pinjaman</h1>
            </div>
        </div>
    </AppLayout>
</template>