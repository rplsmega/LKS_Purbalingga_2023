package com.example.restaurantmobile

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.restaurantmobile.adapter.UserAdapter
import com.example.restaurantmobile.databinding.ActivityMainBinding
import com.example.restaurantmobile.model.User
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.runBlocking
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        updateUI()
    }

    private fun updateUI() = runBlocking{
        launch(Dispatchers.IO){
            val users: MutableList<User> = mutableListOf()
            val conn = URL("https://wahanasuksesbersama.id/lks/data.php").openConnection() as HttpURLConnection
            val inputString = conn.inputStream.bufferedReader().readText()
            val jsonObject = JSONObject(inputString)
            val jsonArray = jsonObject.getJSONArray("item")
            for (i in 0 until jsonArray.length()) {
                val user = jsonArray.getJSONObject(i)
                users.add(User(
                    employeeid = user.getInt("employeeid"),
                    nama = user.getString("nama"),
                    jabatan = user.getString("position")
                ))
            }
            binding.rv.apply {
                adapter = UserAdapter(this@MainActivity, users)
                layoutManager = LinearLayoutManager(this@MainActivity)
            }
        }
    }
}