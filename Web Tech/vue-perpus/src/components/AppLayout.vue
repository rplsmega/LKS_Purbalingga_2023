<script setup>
</script>

<template>
    <nav class="bg-blue-500">
        <div class="container m-auto flex justify-between p-4">
            <h1 class="self-center text-3xl text-white font-semibold cursor-pointer"><router-link to="/">Perpus Digital</router-link></h1>

            <ul class="self-center">
                <li class="text-white p-4 inline-block hover:cursor-pointer hover:bg-blue-400 text-xl"><router-link to="/">Daftar Pinjam</router-link></li>
                <li class="text-white p-4 inline-block hover:cursor-pointer hover:bg-blue-400 text-xl"><router-link to="/">Logout</router-link></li>
            </ul>
        </div>
    </nav>

    <slot />

    <footer class="text-center">
        <p class="font-mono">"Buku jembatan ilmu"</p>
        <p>Copyright &copy; 2023</p>    
    </footer>
</template>