package com.example.restaurantmobile.adapter

import android.content.Context
import android.text.style.TtsSpan.TextBuilder
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.restaurantmobile.R
import com.example.restaurantmobile.model.User

class UserAdapter(
    val context: Context,
    val users: List<User>
): RecyclerView.Adapter<UserAdapter.UViewHolder>() {
    inner class UViewHolder(view: View): RecyclerView.ViewHolder(view) {
        val tvID = view.findViewById<TextView>(R.id.tvID)
        val tvName = view.findViewById<TextView>(R.id.tvName)
        val tvJabatan = view.findViewById<TextView>(R.id.tvJabatan)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): UViewHolder {
        return UViewHolder(LayoutInflater.from(context).inflate(R.layout.row_item, parent, false))
    }

    override fun getItemCount(): Int {
        return users.size
    }

    override fun onBindViewHolder(holder: UViewHolder, position: Int) {
        val user = users[position]
        holder.tvID.text = "ID: ${user.employeeid}"
        holder.tvName.text = "Nama: ${user.nama}"
        holder.tvJabatan.text = "Jabatan: ${user.jabatan}"
    }


}