package com.travelplanner.ui.toDoList

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.RelativeLayout
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.button.MaterialButton
import com.google.android.material.floatingactionbutton.FloatingActionButton
import com.travelplanner.R

class ToDoListFragment : Fragment() {

    lateinit var viewModel: ToDoListViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_to_do_list, container, false)
        viewModel =
                ViewModelProvider(this).get(ToDoListViewModel::class.java)
        val travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        travelId?.let {
            viewModel.setTravelId(it)
        }
        val noData = v.findViewById<ConstraintLayout>(R.id.no_saved_to_do)
        val loadedData = v.findViewById<RelativeLayout>(R.id.saved_to_do)
        val recycler = v.findViewById<RecyclerView>(R.id.to_do_list_recycler)
        val button = v.findViewById<MaterialButton>(R.id.add_to_do_item_button)
        val floatingButton = v.findViewById<FloatingActionButton>(R.id.add_to_do_item_floating_button)
        val textInput = v.findViewById<EditText>(R.id.new_item)
        val adapter = ToDoListAdapter(activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)){
            viewModel.checkItem(it)
        }
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.toDoList.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()){
                noData.visibility = View.GONE
                loadedData.visibility = View.VISIBLE
                adapter.setData(it)
            } else {
                noData.visibility = View.VISIBLE
                recycler.visibility = View.GONE
                button.visibility = View.VISIBLE
                button.setOnClickListener {
                    viewModel.addToFavourites(textInput.text.toString(), travelId)
                }
            }
        })
        floatingButton.setOnClickListener{
            val dialogView = inflater.inflate(R.layout.add_new_to_do_item, container, false)
            val dialogViewTextInput = dialogView.findViewById<EditText>(R.id.new_item)
            AlertDialog.Builder(requireContext())
                .setView(dialogView)
                .setPositiveButton("Add") { _, _->
                    viewModel.addToFavourites(dialogViewTextInput.text.toString(), travelId)
                }
                .setNegativeButton("Cancel"){_,_ -> }
                .show()
        }

        viewModel.checked.observe(viewLifecycleOwner, Observer {p ->
            adapter.updateCheckbox(p.first, p.second)
        })
        viewModel.toastError.observe(viewLifecycleOwner, Observer {p ->
            Toast.makeText(context, p, Toast.LENGTH_SHORT).show()
        })

        return v
    }

    companion object {
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}