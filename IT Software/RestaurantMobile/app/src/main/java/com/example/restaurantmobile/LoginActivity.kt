package com.example.restaurantmobile

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.example.restaurantmobile.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {
    private lateinit var binding : ActivityLoginBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityLoginBinding.inflate(layoutInflater)
        setContentView(binding.root)
        binding.btnLogin.setOnClickListener{
            val user = binding.etUsername.text.toString()
            val password = binding.etPassword.text.toString()
            if (user.isEmpty()){
                binding.etUsername.error = "Input field cannot be empty"
                return@setOnClickListener
            }
            if (password.isEmpty()){
                binding.etPassword.error = "Input field cannot be empty"
                return@setOnClickListener
            }
            if (user != "admin" || password != "12345"){
                Toast.makeText(this@LoginActivity, "User Not Found", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            startActivity(Intent(this@LoginActivity, MainActivity::class.java))
            finish()
        }
    }
}